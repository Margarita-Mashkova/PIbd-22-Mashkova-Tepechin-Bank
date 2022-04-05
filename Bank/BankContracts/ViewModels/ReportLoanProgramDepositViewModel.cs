using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    //Модель для получения списка вкладов по выбранным кредитным программам (роль Кладовщик)
    public class ReportLoanProgramDepositViewModel
    {
        public string LoanProgramName { get; set; }
        public string CurrencyName{ get; set; }
        public List<Tuple<string, decimal>> Deposits { get; set; }
    }
}
