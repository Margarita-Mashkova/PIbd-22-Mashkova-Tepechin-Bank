using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IReplenishmentLogic
    {
        List<ReplenishmentViewModel> Read(ReplenishmentBindingModel model);
        void CreateOrUpdate(ReplenishmentBindingModel model);
        void Delete(ReplenishmentBindingModel model);
    }
}
