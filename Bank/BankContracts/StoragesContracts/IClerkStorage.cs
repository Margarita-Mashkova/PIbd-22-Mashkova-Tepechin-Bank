using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.StoragesContracts
{
    public interface IClerkStorage
    {
        List<ClerkViewModel> GetFullList();

        List<ClerkViewModel> GetFilteredList(ClerkBindingModel model);

        ClerkViewModel GetElement(ClerkBindingModel model);

        void Insert(ClerkBindingModel model);

        void Update(ClerkBindingModel model);

        void Delete(ClerkBindingModel model);
    }
}
