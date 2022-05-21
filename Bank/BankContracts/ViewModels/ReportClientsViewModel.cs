using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    //Модель для получения отчёта по клиентам (роль Работник)
    public class ReportClientsViewModel
    {
        public string ClientFIO { get; set; }
        public DateTime DateVisit { get; set; }
        public List<(DepositViewModel, List<CurrencyViewModel>)> DepositCurrencies { get; set;}
    }
}
