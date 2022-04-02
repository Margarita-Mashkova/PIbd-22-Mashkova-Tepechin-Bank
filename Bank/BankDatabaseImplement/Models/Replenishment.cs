using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDatabaseImplement.Models
{
    public class Replenishment
    {
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime DateReplenishment { get; set; }
        public int DepositId { get; set; }
        public virtual Deposit Deposit { get; set; }
        public int ClerkId { get; set; }
        public virtual Clerk Clerk { get; set; }
    }
}
