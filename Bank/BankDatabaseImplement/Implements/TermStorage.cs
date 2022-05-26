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
    public class TermStorage : ITermStorage
    {
        public void Delete(TermBindingModel model)
        {
            using var context = new BankDatabase();
            Term element = context.Terms.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Terms.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public TermViewModel GetElement(TermBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            var order = context.Terms
            .Include(rec => rec.LoanProgram)
            .Include(rec => rec.Manager)
            .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public List<TermViewModel> GetFilteredList(TermBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BankDatabase();
            return context.Terms
            .Include(rec => rec.LoanProgram)
            .Include(rec => rec.Manager)
            .Where(rec => (rec.Id == model.Id) || (model.ManagerId.HasValue && rec.ManagerId == model.ManagerId))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<TermViewModel> GetFullList()
        {
            using var context = new BankDatabase();
            return context.Terms
            .Include(rec => rec.LoanProgram)
            .Include(rec => rec.Manager)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(TermBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Terms.Add(CreateModel(model, new Term()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(TermBindingModel model)
        {
            using var context = new BankDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Terms.FirstOrDefault(rec => rec.Id ==
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
        private static Term CreateModel(TermBindingModel model, Term term)
        {
            term.LoanProgramId = (int)model.LoanProgramId;
            term.ManagerId = (int)model.ManagerId;
            term.StartTerm = model.StartTerm;
            term.EndTerm = model.EndTerm;
            return term;
        }
        private static TermViewModel CreateModel(Term term)
        {
            return new TermViewModel
            {
                Id = term.Id,
                LoanProgramId = term.LoanProgramId,
                LoanProgramName = term.LoanProgram.LoanProgramName,
                StartTerm = term.StartTerm,
                EndTerm = term.EndTerm
            };
        }
    }
}
