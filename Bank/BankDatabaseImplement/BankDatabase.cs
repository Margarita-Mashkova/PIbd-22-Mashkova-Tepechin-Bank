using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankDatabaseImplement.Models;

namespace BankDatabaseImplement
{
    public class BankDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BankDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Clerk> Clerks { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<ClientDeposit> ClientDeposits { set; get; }
        public virtual DbSet<ClientLoanProgram> ClientLoanPrograms { set; get; }
        public virtual DbSet<Currency> Currencies { set; get; }
        public virtual DbSet<Deposit> Deposits { set; get; }
        public virtual DbSet<DepositCurrency> DepositCurrencies { set; get; }
        public virtual DbSet<LoanProgram> LoanPrograms { set; get; }
        public virtual DbSet<LoanProgramCurrency> LoanProgramCurrencies { set; get; }
        public virtual DbSet<Manager> Managers { set; get; }
        public virtual DbSet<Replenishment> Replenishments { set; get; }
        public virtual DbSet<Term> Terms { set; get; }
    }
}
