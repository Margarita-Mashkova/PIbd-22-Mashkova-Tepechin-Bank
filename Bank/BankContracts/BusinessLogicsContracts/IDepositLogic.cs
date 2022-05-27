using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IDepositLogic
    {
        List<DepositViewModel> Read(DepositBindingModel model);
        void CreateOrUpdate(DepositBindingModel model);
        void Delete(DepositBindingModel model);
        void AddClients(AddClientsBindingModel model);
    }
}
