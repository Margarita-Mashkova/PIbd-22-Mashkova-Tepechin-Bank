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
            .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateVisit.Date == model.DateVisit.Date) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateVisit.Date >= model.DateFrom.Value.Date && rec.DateVisit.Date <= model.DateTo.Value.Date) ||
            (model.ClerkId.HasValue && rec.ClerkId == model.ClerkId))
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
                    TelephoneNumber = model.TelephoneNumber,
                    DateVisit = model.DateVisit,
                    ClerkId = (int)model.ClerkId
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
            client.ClerkId = (int)model.ClerkId;
            client.PassportData = model.PassportData;
            client.TelephoneNumber = model.TelephoneNumber;
            client.DateVisit = model.DateVisit;
            if (model.Id.HasValue)
            {
                var clientLoanPrograms = context.ClientLoanPrograms.Where(rec => rec.ClientId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ClientLoanPrograms.RemoveRange(clientLoanPrograms.Where(rec => !model.ClientLoanPrograms.ContainsKey(rec.LoanProgramId)).ToList());
                context.SaveChanges();
            }
            // добавили новые
            foreach (var clp in model.ClientLoanPrograms)
            {
                context.ClientLoanPrograms.Add(new ClientLoanProgram
                {
                    ClientId = client.Id,
                    LoanProgramId = clp.Key
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
                DateVisit = client.DateVisit,
                ClientLoanPrograms = client.ClientLoanPrograms
                .ToDictionary(recCLP => recCLP.LoanProgramId, recCLP => recCLP.LoanProgram?.LoanProgramName)
            };
        }
    }
}
