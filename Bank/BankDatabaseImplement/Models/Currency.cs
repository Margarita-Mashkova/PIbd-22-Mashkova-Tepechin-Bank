using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        [Required]
        public decimal RubExchangeRate { get; set; }
        public virtual List<LoanProgramCurrency> LoanProgramCurrencies { get; set; }
    }
}
