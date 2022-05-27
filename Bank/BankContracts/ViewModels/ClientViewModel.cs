using System.ComponentModel;

namespace BankContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DisplayName("Паспортные данные")]
        public string PassportData { get; set; }

        [DisplayName("Контактный телефон")]
        public string TelephoneNumber { get; set; }

        [DisplayName("Дата визита")]
        public DateTime DateVisit { get; set; }
        public Dictionary<int, string> ClientLoanPrograms { get; set; }
    }
}
