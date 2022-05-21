using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using BankContracts.BindingModels;
using BankDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDatabaseImplement.Implements
{
    public class ClerkStorage : IClerkStorage
    {
        public List<ClerkViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Clerks
                .Select(CreateModel)
                .ToList();
        }
        public List<ClerkViewModel> GetFilteredList(ClerkBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.Clerks
            .Include(rec => rec.Replenishments)
            .Include(rec => rec.Deposits)
            .Include(rec => rec.Clients)
            .Where(rec => rec.Email == model.Email)
            .Select(CreateModel)
            .ToList();
        }
        public ClerkViewModel GetElement(ClerkBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var clerk = context.Clerks
            .Include(rec => rec.Replenishments)
            .Include(rec => rec.Deposits)
            .Include(rec => rec.Clients)
            .FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
            return clerk != null ? CreateModel(clerk) : null;
        }
        public void Insert(ClerkBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Clerks.Add(CreateModel(model, new Clerk()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ClerkBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Clerks.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ClerkBindingModel model)
        {
            using var context = new BankDatabase();
            Clerk element = context.Clerks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clerks.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Clerk CreateModel(ClerkBindingModel model, Clerk clerk)
        {
            clerk.ClerkFIO = model.ClerkFIO;
            clerk.Email = model.Email;
            clerk.Password = model.Password;
            return clerk;
        }
        private static ClerkViewModel CreateModel(Clerk clerk)
        {
            return new ClerkViewModel
            {
                Id = clerk.Id,
                ClerkFIO = clerk.ClerkFIO,
                Email = clerk.Email,
                Password = clerk.Password
            };
        }
    }
}
