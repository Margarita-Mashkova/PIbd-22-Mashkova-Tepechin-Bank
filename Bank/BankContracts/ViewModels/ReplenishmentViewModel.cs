using System.ComponentModel;

namespace BankContracts.ViewModels
{
    public class ReplenishmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Сумма пополнения")]
        public int Amount { get; set; }

        [DisplayName("Дата пополнения")]
        public DateTime DateReplenishment { get; set; }
        public int DepositId { get; set; }
        public string DepositName { get; set; }
    }
}
