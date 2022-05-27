using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;

namespace BankBusinessLogic.BusinessLogics
{
    public class ReplenishmentLogic : IReplenishmentLogic
    {
        private readonly IReplenishmentStorage _replenishmentStorage;
        public ReplenishmentLogic(IReplenishmentStorage replenishmentStorage)
        {
            _replenishmentStorage = replenishmentStorage;
        }
        public List<ReplenishmentViewModel> Read(ReplenishmentBindingModel model)
        {
            if (model == null)
            {
                return _replenishmentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ReplenishmentViewModel> { _replenishmentStorage.GetElement(model) };
            }
            return _replenishmentStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ReplenishmentBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _replenishmentStorage.Update(model);
            }
            else
            {
                _replenishmentStorage.Insert(model);
            }
        }
        public void Delete(ReplenishmentBindingModel model)
        {
            var element = _replenishmentStorage.GetElement(new ReplenishmentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _replenishmentStorage.Delete(model);
        }
    }
}
