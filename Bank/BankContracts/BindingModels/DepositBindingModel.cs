
namespace BankContracts.BindingModels
{
    public class DepositBindingModel
    {
        public int? Id { get; set; }
        public string DepositName { get; set; }
        public decimal DepositInterest { get; set; }
        public Dictionary<int, string> DepositClients { get; set; }
        public int? ClerkId { get; set; }
    }
}
