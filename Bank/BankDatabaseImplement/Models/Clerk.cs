using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDatabaseImplement.Models
{
    public class Clerk
    {
        public int Id { get; set; }

        [Required]
        public string ClerkFIO { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("ClerkId")]
        public virtual List<Replenishment> Replenishments { get; set; }

        [ForeignKey("ClerkId")]
        public virtual List<Deposit> Deposits { get; set; }

        [ForeignKey("ClerkId")]
        public virtual List<Client> Clients { get; set; }
    }
}
