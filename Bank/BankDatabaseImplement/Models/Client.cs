using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string ClientFIO { get; set; }

        [Required]
        public string PassportData { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public DateTime DateVisit { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<ClientLoanProgram> ClientLoanPrograms { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<ClientDeposit> ClientDeposits { get; set; }
        public int ClerkId { get; set; }
        public virtual Clerk Clerk { get; set; }
    }
}
