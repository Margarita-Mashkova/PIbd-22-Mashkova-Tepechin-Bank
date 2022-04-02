using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [Required]
        public string ManagerFIO { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("ManagerId")]
        public virtual List<Term> Terms { get; set; }
        [ForeignKey("ManagerId")]
        public virtual List<LoanProgram> LoanPrograms { get; set; }
        [ForeignKey("ManagerId")]
        public virtual List<Currency> Currencies { get; set; }
    }
}
