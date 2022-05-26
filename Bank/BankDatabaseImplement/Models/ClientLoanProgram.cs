using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabaseImplement.Models
{
    public class ClientLoanProgram
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int LoanProgramId { get; set; }
        public virtual Client Client { get; set; }
        public virtual LoanProgram LoanProgram { get; set; }
    }
}
