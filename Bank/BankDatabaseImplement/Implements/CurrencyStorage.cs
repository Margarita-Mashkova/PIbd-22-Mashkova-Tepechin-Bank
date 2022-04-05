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
    public class CurrencyStorage : ICurrencyStorage
    {
        public void Delete(CurrencyBindingModel model)
        {
            using var context = new BankDatabase();
            Currency element = context.Currencies.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Currencies.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public CurrencyViewModel GetElement(CurrencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var currency = context.Currencies
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.LoanProgram)
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.Manager)
            .FirstOrDefault(rec => rec.CurrencyName == model.CurrencyName || rec.Id == model.Id);
            return currency != null ? CreateModel(currency) : null;
        }

        public List<CurrencyViewModel> GetFilteredList(CurrencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();

            return context.Currencies
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.LoanProgram)
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.Manager)
            .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateAdding.Date == model.DateAdding.Date) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateAdding.Date >= model.DateFrom.Value.Date && rec.DateAdding.Date <= model.DateTo.Value.Date) ||
            (model.ManagerId.HasValue && rec.ManagerId == model.ManagerId))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<CurrencyViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Currencies
            .Include(rec => rec.LoanProgramCurrencies)
            .ThenInclude(rec => rec.LoanProgram)
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Deposit)
            .Include(rec => rec.Manager)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(CurrencyBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Currencies.Add(CreateModel(model, new Currency(), context));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(CurrencyBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Currencies.FirstOrDefault(rec => rec.Id ==
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
        private static Currency CreateModel(CurrencyBindingModel model, Currency currency, BankDatabase context)
        {
            currency.CurrencyName = model.CurrencyName;
            currency.RubExchangeRate = model.RubExchangeRate;
            currency.ManagerId = (int)model.ManagerId;
            currency.DateAdding = model.DateAdding;
            if (model.Id.HasValue)
            {
                var currencyDeposit = context.DepositCurrencies.Where(rec => rec.DepositId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.DepositCurrencies.RemoveRange(currencyDeposit.Where(rec => !model.CurrencyDeposits.ContainsKey(rec.DepositId)).ToList());
                context.SaveChanges();
            }
            // добавили новые
            foreach (var cd in model.CurrencyDeposits)
            {
                context.DepositCurrencies.Add(new DepositCurrency
                {
                    DepositId = cd.Key,
                    CurrencyId = currency.Id,
                });
                context.SaveChanges();
            }
            return currency;
        }
        private static CurrencyViewModel CreateModel(Currency currency)
        {
            return new CurrencyViewModel
            {
                Id = currency.Id,
                CurrencyName = currency.CurrencyName,
                RubExchangeRate = currency.RubExchangeRate,
                DateAdding = currency.DateAdding,
                CurrencyDeposits= currency.DepositCurrencies
            .ToDictionary(recII => recII.DepositId,
            recII => (recII.Deposit?.DepositName, recII.Deposit.DepositInterest))
            };
        }
    }
}
