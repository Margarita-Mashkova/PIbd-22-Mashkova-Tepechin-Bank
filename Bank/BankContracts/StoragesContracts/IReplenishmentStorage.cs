using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.StoragesContracts
{
    public interface IReplenishmentStorage
    {
        List<ReplenishmentViewModel> GetFullList();

        List<ReplenishmentViewModel> GetFilteredList(ReplenishmentBindingModel model);

        ReplenishmentViewModel GetElement(ReplenishmentBindingModel model);

        void Insert(ReplenishmentBindingModel model);

        void Update(ReplenishmentBindingModel model);

        void Delete(ReplenishmentBindingModel model);
    }
}
