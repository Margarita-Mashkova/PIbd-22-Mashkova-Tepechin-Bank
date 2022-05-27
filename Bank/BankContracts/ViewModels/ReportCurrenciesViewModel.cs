
namespace BankContracts.ViewModels
{
    //Модель для получения отчёта по валютам (роль Кладовщик)
    public class ReportCurrenciesViewModel
    {
        public string CurrencyName { get; set; }
        public DateTime DateAdding { get; set; }
        public string Deposits { get; set; }
        public string LoanPrograms { get; set; }
    }
}
