using BankContracts.BindingModels;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using BankDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Implements
{
    public class ManagerStorage : IManagerStorage
    {
        public void Delete(ManagerBindingModel model)
        {
            using var context = new BankDatabase();
            Manager element = context.Managers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Managers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }

        public ManagerViewModel GetElement(ManagerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();

            var manager = context.Managers.Include(x => x.Terms).Include(x => x.LoanPrograms).Include(x => x.Currencies)
            .FirstOrDefault(rec => rec.Email == model.Email ||
            rec.Id == model.Id);
            return manager != null ?
            new ManagerViewModel
            {
                Id = manager.Id,
                ManagerFIO = manager.ManagerFIO,
                Email = manager.Email,
                Password = manager.Password,
            } :
            null;
        }

        public List<ManagerViewModel> GetFilteredList(ManagerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();

            return context.Managers.Include(x => x.Terms).Include(x => x.LoanPrograms).Include(x => x.Currencies)
            .Where(rec => rec.Email == model.Email && rec.Password == model.Password)
            .Select(rec => new ManagerViewModel
            {
                Id = rec.Id,
                ManagerFIO = rec.ManagerFIO,
                Email = rec.Email,
                Password = rec.Password,
            })
            .ToList();
        }

        public List<ManagerViewModel> GetFullList()
        {
            using var context = new BankDatabase();

            return context.Managers.Select(rec => new ManagerViewModel
            {
                Id = rec.Id,
                ManagerFIO = rec.ManagerFIO,
                Email = rec.Email,
                Password = rec.Password,
            })
            .ToList();
        }

        public void Insert(ManagerBindingModel model)
        {
            using var context = new BankDatabase();

            context.Managers.Add(CreateModel(model, new Manager()));
            context.SaveChanges();
        }

        public void Update(ManagerBindingModel model)
        {
            using var context = new BankDatabase();

            var element = context.Managers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Руководитель не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        private Manager CreateModel(ManagerBindingModel model, Manager manager)
        {
            manager.ManagerFIO = model.ManagerFIO;
            manager.Email = model.Email;
            manager.Password = model.Password;
            return manager;
        }
    }
}
