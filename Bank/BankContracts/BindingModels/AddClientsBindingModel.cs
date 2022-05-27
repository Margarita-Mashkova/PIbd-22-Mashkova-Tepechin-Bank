
namespace BankContracts.BindingModels
{
    public class AddClientsBindingModel
    {
        public int DepositId { get; set; }
        public List<int> ClientsId { get; set; }
    }
}
