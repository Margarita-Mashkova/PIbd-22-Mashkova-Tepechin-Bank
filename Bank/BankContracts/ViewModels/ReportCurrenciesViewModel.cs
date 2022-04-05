using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    //Модель для получения отчёта по валютам (роль Кладовщик)
    public class ReportCurrenciesViewModel
    {
        public string CurrencyName { get; set; }
        public DateTime DateAdding { get; set; }
        public List<DepositViewModel> Deposits { get; set; }
        public List<LoanProgramViewModel> LoanPrograms { get; set; }
    }
}
