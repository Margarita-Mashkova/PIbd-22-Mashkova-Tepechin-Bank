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
        public virtual List<ClientDeposit> ClientDeposits { get; set; }

    }
}
