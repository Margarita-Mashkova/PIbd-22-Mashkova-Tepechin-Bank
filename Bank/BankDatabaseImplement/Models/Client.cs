using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [ForeignKey("ClientId")]
        public virtual List<ClientLoanProgram> ClientLoanPrograms { get; set; }
    }
}
