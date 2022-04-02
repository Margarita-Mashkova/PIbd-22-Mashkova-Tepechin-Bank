using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class Term
    {
        public int? Id { get; set; }
        [Required]
        public DateTime StartTerm { get; set; }
        [Required]
        public DateTime EndTerm { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual LoanProgram LoanProgram { get; set; }
    }
}
