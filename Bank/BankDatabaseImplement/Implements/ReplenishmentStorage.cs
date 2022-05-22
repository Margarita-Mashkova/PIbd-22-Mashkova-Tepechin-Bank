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
    public class ReplenishmentStorage : IReplenishmentStorage
    {
        public List<ReplenishmentViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Replenishments
                .Include(rec => rec.Deposit)
                .Select(CreateModel)
                .ToList();
        }
        public List<ReplenishmentViewModel> GetFilteredList(ReplenishmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.Replenishments
                .Include(rec => rec.Deposit)
                .Where(rec => (rec.Id == model.Id) || (model.ClerkId.HasValue && rec.ClerkId == model.ClerkId)) 
                .Select(CreateModel)
                .ToList();
        }
        public ReplenishmentViewModel GetElement(ReplenishmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var replenishment = context.Replenishments
                .Include(rec => rec.Deposit)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return replenishment != null ? CreateModel(replenishment) : null;
        }
        public void Insert(ReplenishmentBindingModel model)
        {
            using var context = new BankDatabase();
            context.Replenishments.Add(CreateModel(model, new Replenishment()));
            context.SaveChanges();
        }
        public void Update(ReplenishmentBindingModel model)
        {
            using var context = new BankDatabase();
            var element = context.Replenishments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ReplenishmentBindingModel model)
        {
            using var context = new BankDatabase();
            Replenishment element = context.Replenishments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Replenishments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Replenishment CreateModel(ReplenishmentBindingModel model, Replenishment replenishment)
        {
            replenishment.DateReplenishment = model.DateReplenishment;
            replenishment.Amount = model.Amount;
            replenishment.ClerkId = (int)model.ClerkId;
            replenishment.DepositId = model.DepositId;
            return replenishment;
        }
        private static ReplenishmentViewModel CreateModel(Replenishment replenishment)
        {
            return new ReplenishmentViewModel
            {
                Id = replenishment.Id,
                Amount = replenishment.Amount,
                DateReplenishment = replenishment.DateReplenishment,
                DepositId = replenishment.DepositId,
                DepositName = replenishment.Deposit.DepositName
            };
        }
    }
}
