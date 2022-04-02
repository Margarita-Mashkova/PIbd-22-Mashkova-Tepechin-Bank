using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class DepositCurrency
    {
        public int Id { get; set; }
        public int DepositId { get; set; }
        public int CurrencyId { get; set; }
        public virtual Deposit Deposit { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
