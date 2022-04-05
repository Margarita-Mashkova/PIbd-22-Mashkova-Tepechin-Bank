using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDatabaseImplement.Models
{
    public class Deposit
    {
        public int Id { get; set; }
        
        [Required]
        public string DepositName { get; set; }

        [Required]
        public decimal DepositInterest { get; set; }

        [ForeignKey("DepositId")]
        public virtual List<ClientDeposit> DepositClients { get; set; }

        [ForeignKey("DepositId")]
        public virtual List<DepositCurrency> DepositCurrencies { get; set; }

        [ForeignKey("DepositId")]
        public virtual List<Replenishment> Replenishments { get; set; }
        public int ClerkId { get; set; }
        public virtual Clerk Clerk { get; set; }
    }
}
