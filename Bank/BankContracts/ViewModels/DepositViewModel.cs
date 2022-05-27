using System.ComponentModel;

namespace BankContracts.ViewModels
{
    public class DepositViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование вклада")]
        public string DepositName { get; set; }

        [DisplayName("Процентная ставка")]
        public decimal DepositInterest { get; set; }
        public Dictionary<int, string> DepositClients { get; set; }
        public int? ClerkId { get; set; }
    }
}
