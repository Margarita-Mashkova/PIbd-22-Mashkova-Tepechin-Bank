using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class LoanProgramCurrency
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int LoanProgramId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual LoanProgram LoanProgram { get; set; }
    }
}
