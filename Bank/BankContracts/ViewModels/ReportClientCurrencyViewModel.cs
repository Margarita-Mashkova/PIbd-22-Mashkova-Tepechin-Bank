using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.ViewModels
{
    //Модель для получения списка валют по выбранным клиентам (роль Работник)
    public class ReportClientCurrencyViewModel
    {
        public string ClientFIO { get; set; }
        public string LoanProgramName { get; set; }
        public List<string> Currencies { get; set; }
    }
}
