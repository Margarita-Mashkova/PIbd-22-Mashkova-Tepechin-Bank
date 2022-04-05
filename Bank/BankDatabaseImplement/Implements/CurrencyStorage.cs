﻿using BankContracts.BindingModels;
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
                context.Currencies.Add(CreateModel(model, new Currency()));
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
        private static Currency CreateModel(CurrencyBindingModel model, Currency currency)
        {
            currency.CurrencyName = model.CurrencyName;
            currency.RubExchangeRate = model.RubExchangeRate;
            currency.ManagerId = (int)model.ManagerId;
            currency.DateAdding = model.DateAdding;
            //TODO: прописать словарь (DepositStorage)
            return currency;
        }
        private static CurrencyViewModel CreateModel(Currency currency)
        {
            return new CurrencyViewModel
            {
                Id = currency.Id,
                CurrencyName = currency.CurrencyName,
                RubExchangeRate = currency.RubExchangeRate,
                DateAdding = currency.DateAdding
                //TODO: прописать словарь (DepositStorage)
            };
        }
    }
}
