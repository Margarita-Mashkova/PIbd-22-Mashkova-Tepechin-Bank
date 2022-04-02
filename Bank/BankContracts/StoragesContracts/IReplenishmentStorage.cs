using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface IReplenishmentStorage
    {
        //TODO: во всех интерфейсах сторэдж проверить методы
        List<ReplenishmentViewModel> GetFullList();

        List<ReplenishmentViewModel> GetFilteredList(ReplenishmentBindingModel model);

        ReplenishmentViewModel GetElement(ReplenishmentBindingModel model);

        void Insert(ReplenishmentBindingModel model);

        void Update(ReplenishmentBindingModel model);

        void Delete(ReplenishmentBindingModel model);
    }
}
