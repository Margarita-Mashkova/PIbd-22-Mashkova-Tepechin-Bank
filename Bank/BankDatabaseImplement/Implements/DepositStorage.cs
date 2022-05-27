using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using BankContracts.BindingModels;
using BankDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDatabaseImplement.Implements
{
    public class DepositStorage : IDepositStorage
    {
        public List<DepositViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Deposits
            .Include(rec => rec.DepositClients)
            .ThenInclude(rec => rec.Client)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<DepositViewModel> GetFilteredList(DepositBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.Deposits
            .Include(rec => rec.DepositClients)
            .ThenInclude(rec => rec.Client)
            .Where(rec => (rec.DepositName.Contains(model.DepositName)) || (model.ClerkId.HasValue && rec.ClerkId == model.ClerkId))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public DepositViewModel GetElement(DepositBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var deposit = context.Deposits
            .Include(rec => rec.DepositClients)
            .ThenInclude(rec => rec.Client)
            .FirstOrDefault(rec => rec.DepositName == model.DepositName || rec.Id == model.Id);
            return deposit != null ? CreateModel(deposit) : null;
        }
        public void Insert(DepositBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Deposit deposit = new Deposit()
                {
                    DepositName = model.DepositName,
                    DepositInterest = model.DepositInterest,
                    ClerkId = (int)model.ClerkId
                };
                context.Deposits.Add(deposit);
                context.SaveChanges();
                CreateModel(model, deposit, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(DepositBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Deposits.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(DepositBindingModel model)
        {
            using var context = new BankDatabase();
            Deposit element = context.Deposits.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                var depositClients = context.ClientDeposits.Where(rec => rec.DepositId == element.Id).ToList();
                context.ClientDeposits.RemoveRange(depositClients);
                var depositReplenisments = context.Replenishments.Where(rec => rec.DepositId == element.Id).ToList();
                context.Replenishments.RemoveRange(depositReplenisments);
                context.Deposits.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Deposit CreateModel(DepositBindingModel model, Deposit deposit, BankDatabase context)
        {
            deposit.DepositName = model.DepositName;
            deposit.DepositInterest = model.DepositInterest;
            deposit.ClerkId = (int)model.ClerkId;
            if (model.Id.HasValue)
            {
                var clientDeposits = context.ClientDeposits.Where(rec => rec.DepositId == model.Id.Value).ToList();
                context.ClientDeposits.RemoveRange(clientDeposits);
                context.SaveChanges();
            }
            // добавили новые
            foreach (var cd in model.DepositClients)
            {
                context.ClientDeposits.Add(new ClientDeposit
                {
                    DepositId = deposit.Id,
                    ClientId = cd.Key,
                });
                context.SaveChanges();
            }            
            return deposit;
        }
        private static DepositViewModel CreateModel(Deposit deposit)
        {
            return new DepositViewModel
            {
                Id = deposit.Id,
                ClerkId = deposit.ClerkId,
                DepositName = deposit.DepositName,
                DepositInterest = deposit.DepositInterest,
                DepositClients = deposit.DepositClients
                .ToDictionary(recDC => recDC.ClientId, recDC => recDC.Client?.ClientFIO)
            };
        }
    }
}
