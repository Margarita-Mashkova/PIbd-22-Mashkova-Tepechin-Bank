using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BindingModels
{
    public class LoanProgramBindingModel
    {
        public int? Id { get; set; }
        public string LoanProgramName { get; set; }
        public decimal InterestRate { get; set; }
    }
}
