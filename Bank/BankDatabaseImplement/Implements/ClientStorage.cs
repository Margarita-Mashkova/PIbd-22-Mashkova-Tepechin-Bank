using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using BankContracts.BindingModels;
using BankDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Clients
            .Include(rec => rec.ClientDeposits)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.LoanProgram)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.Clients
            .Include(rec => rec.ClientDeposits)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.LoanProgram)
            .Where(rec => rec.PassportData.Contains(model.PassportData))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var client = context.Clients
            .Include(rec => rec.ClientDeposits)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.LoanProgram)
            .FirstOrDefault(rec => rec.PassportData == model.PassportData || rec.Id == model.Id);
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Client client = new Client()
                {
                    ClientFIO = model.ClientFIO,
                    PassportData = model.PassportData,
                    TelephoneNumber = model.TelephoneNumber
                };
                context.Clients.Add(client);
                context.SaveChanges();
                CreateModel(model, client, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ClientBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using var context = new BankDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Client CreateModel(ClientBindingModel model, Client client, BankDatabase context)
        {
            client.ClientFIO = model.ClientFIO;
            client.ClerkId = (int)model.ClerkId; //TODO: надо?
            client.PassportData = model.PassportData;
            client.TelephoneNumber = model.TelephoneNumber;
            if (model.Id.HasValue)
            {
                var clientLoanPrograms = context.ClientLoanPrograms.Where(rec => rec.ClientId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ClientLoanPrograms.RemoveRange(clientLoanPrograms.Where(rec => !model.ClientLoanPrograms.ContainsKey(rec.LoanProgramId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateLoanProgram in clientLoanPrograms)
                {
                    updateLoanProgram.Count = model.ClientLoanPrograms[updateLoanProgram.LoanProgramId].Item2;
                    model.ClientLoanPrograms.Remove(updateLoanProgram.LoanProgramId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var clp in model.ClientLoanPrograms)
            {
                context.ClientLoanPrograms.Add(new ClientLoanProgram
                {
                    ClientId = client.Id,
                    LoanProgramId = clp.Key,
                    Count = clp.Value.Item2
                });
                context.SaveChanges();
            }
            return client;
        }
        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                PassportData = client.PassportData,
                TelephoneNumber = client.TelephoneNumber,
                ClientLoanPrograms = client.ClientLoanPrograms
                .ToDictionary(recCLP => recCLP.LoanProgramId, recCLP => (recCLP.LoanProgram?.LoanProgramName, recCLP.Count))
            };
        }
    }
}
