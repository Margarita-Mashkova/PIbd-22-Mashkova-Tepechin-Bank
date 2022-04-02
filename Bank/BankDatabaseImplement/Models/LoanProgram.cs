using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class LoanProgram
    {
        public int Id { get; set; }

        [Required]
        public string LoanProgramName { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [ForeignKey("LoanProgramId")]
        public virtual List<ClientLoanProgram> ClientLoanPrograms { get; set; }
        [ForeignKey("LoanProgramId")]
        public virtual List<LoanProgramCurrencies> LoanProgramCurrencies { get; set; }

    }
}
