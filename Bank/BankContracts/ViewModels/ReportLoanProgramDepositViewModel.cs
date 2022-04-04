using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class ReportLoanProgramDepositViewModel
    {
        public string LoanProgramName { get; set; }
        public string CurrencyName{ get; set; }
        public List<Tuple<string>> Deposits { get; set; }
    }
}
