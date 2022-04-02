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
    public class LoanProgramStorage : ILoanProgramStorage
    {
        public void Delete(LoanProgramBindingModel model)
        {
            using var context = new BankDatabase();
            LoanProgram element = context.LoanPrograms.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.LoanPrograms.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }

        }

        public LoanProgramViewModel GetElement(LoanProgramBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var loanProgram = context.LoanPrograms
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.Currency)
            .FirstOrDefault(rec => rec.LoanProgramName == model.LoanProgramName ||
            rec.Id == model.Id);
            return loanProgram != null ? CreateModel(loanProgram) : null;
        }

        public List<LoanProgramViewModel> GetFilteredList(LoanProgramBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.LoanPrograms
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.Currency)
            .Where(rec => rec.LoanProgramName.Contains(model.LoanProgramName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<LoanProgramViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.LoanPrograms
            .Include(rec => rec.ClientLoanPrograms)
            .ThenInclude(rec => rec.Client)
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.Currency)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(LoanProgramBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                LoanProgram iceCream = new LoanProgram()
                {
                    LoanProgramName = model.LoanProgramName,
                    InterestRate = model.InterestRate

                };
                context.LoanPrograms.Add(iceCream);
                context.SaveChanges();
                CreateModel(model, iceCream, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(LoanProgramBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.LoanPrograms.FirstOrDefault(rec => rec.Id ==
                model.Id);
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
        private static LoanProgram CreateModel(LoanProgramBindingModel model, LoanProgram loanProgram, BankDatabase context)
        {
            loanProgram.LoanProgramName = model.LoanProgramName;
            loanProgram.InterestRate = model.InterestRate;
            if (model.Id.HasValue)
            {
                var loanProgramCurrencies = context.LoanProgramCurrencies.Where(rec =>
               rec.LoanProgramId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.LoanProgramCurrencies.RemoveRange(loanProgramCurrencies.Where(rec =>
               !model.LoanProgramCurrencies.ContainsKey(rec.CurrencyId)).ToList());
                context.SaveChanges();
            }
            foreach (var lpc in model.LoanProgramCurrencies)
            {
                context.LoanProgramCurrencies.Add(new LoanProgramCurrency
                {
                    LoanProgramId = loanProgram.Id,
                    CurrencyId = lpc.Key,
                });
                context.SaveChanges();
            }
            return loanProgram;
        }
        private static LoanProgramViewModel CreateModel(LoanProgram iceCream)
        {
            return new LoanProgramViewModel
            {
                Id = iceCream.Id,
                LoanProgramName = iceCream.LoanProgramName,
                InterestRate = iceCream.InterestRate,
                LoanProgramCurrencies = iceCream.LoanProgramCurrencies
            .ToDictionary(recII => recII.CurrencyId,
            recII => (recII.Currency?.CurrencyName))
            };
        }
    }
}
