using BankContracts.BindingModels;
using BankContracts.ViewModels;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IReplenishmentLogic
    {
        List<ReplenishmentViewModel> Read(ReplenishmentBindingModel model);
        void CreateOrUpdate(ReplenishmentBindingModel model);
        void Delete(ReplenishmentBindingModel model);
    }
}
