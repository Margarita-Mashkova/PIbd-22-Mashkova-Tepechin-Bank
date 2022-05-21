using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankContracts.ViewModels;

namespace BankBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportClientCurrencyViewModel> ClientCurrency { get; set; }
        public List<ReportLoanProgramDepositViewModel> LoanProgramDeposit { get; set; }
    }
}
