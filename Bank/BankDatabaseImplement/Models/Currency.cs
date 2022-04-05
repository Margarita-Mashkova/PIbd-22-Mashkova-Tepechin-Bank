using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public DateTime DateAdding { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual List<LoanProgramCurrency> LoanProgramCurrencies { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual List<DepositCurrency> DepositCurrencies { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
