using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    public class ReportClientCurrencyViewModel
    {
        public string ClientFIO { get; set; }
        public string LoanProgramName { get; set; }
        public List<Tuple<string>> Currencies { get; set; }
    }
}
