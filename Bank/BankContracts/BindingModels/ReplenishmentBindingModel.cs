
namespace BankContracts.BindingModels
{
    public class ReplenishmentBindingModel
    {
        public int? Id { get; set; }
        public int Amount { get; set; }
        public int DepositId { get; set;}
        public int? ClerkId { get; set; }
        public DateTime DateReplenishment { get; set; }
    }
}
