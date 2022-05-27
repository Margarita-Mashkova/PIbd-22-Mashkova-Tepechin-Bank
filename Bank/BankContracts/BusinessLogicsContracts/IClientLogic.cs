using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
