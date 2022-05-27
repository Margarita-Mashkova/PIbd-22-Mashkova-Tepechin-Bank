
namespace BankContracts.ViewModels
{
    //Модель для получения списка валют по выбранным клиентам (роль Работник)
    public class ReportClientCurrencyViewModel
    {
        public string ClientFIO { get; set; }
        public List<string> Currencies { get; set; }
    }
}
