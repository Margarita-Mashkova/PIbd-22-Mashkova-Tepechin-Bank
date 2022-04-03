﻿using System;
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
    public class DepositStorage : IDepositStorage
    {
        public List<DepositViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Deposits
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Currency)
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
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Currency)
            .Where(rec => rec.DepositName.Contains(model.DepositName))
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
            .Include(rec => rec.DepositCurrencies)
            .ThenInclude(rec => rec.Currency)
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
                    ClerkId = (int)model.ClerkId, //TODO: nado?
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
                context.Deposits.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        //TODO: доделать
        private static Deposit CreateModel(DepositBindingModel model, Deposit deposit, BankDatabase context)
        {
            deposit.DepositName = model.DepositName;
            deposit.DepositInterest = model.DepositInterest;
            //deposit.ClerkId = (int)model.ClerkId; //TODO: nado?
            /*if (model.Id.HasValue)
            {
                var depositCurrencies = context.DepositCurrencies.Where(rec => rec.DepositId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.DepositCurrencies.RemoveRange(depositCurrencies.Where(rec => !model.DepositCurrencies.ContainsKey(rec.CurrencyId)).ToList());
                context.SaveChanges();
            }
            // добавили новые
            foreach (var dc in model.DepositCurrencies)
            {
                context.DepositCurrencies.Add(new DepositCurrency
                {
                    DepositId = deposit.Id,
                    CurrencyId = dc.Key,
                });
                context.SaveChanges();
            }*/
            return deposit;
        }
        private static DepositViewModel CreateModel(Deposit deposit)
        {
            return new DepositViewModel
            {
                Id = deposit.Id,
                DepositName = deposit.DepositName,
                DepositInterest = deposit.DepositInterest,
                //DepositCurrencies = deposit.DepositCurrencies
                //.ToDictionary(recDC => recDC.CurrencyId, recDC => recDC.Currency?.CurrencyName)
            };
        }
    }
}
