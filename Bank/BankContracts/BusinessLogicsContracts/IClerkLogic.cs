using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IClerkLogic
    {
        List<ClerkViewModel> Read(ClerkBindingModel model);
        void CreateOrUpdate(ClerkBindingModel model);
        void Delete(ClerkBindingModel model);
    }
}
