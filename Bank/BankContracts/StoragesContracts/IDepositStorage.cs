using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface IDepositStorage
    {
        List<DepositViewModel> GetFullList();

        List<DepositViewModel> GetFilteredList(DepositBindingModel model);

        DepositViewModel GetElement(DepositBindingModel model);

        void Insert(DepositBindingModel model);

        void Update(DepositBindingModel model);

        void Delete(DepositBindingModel model);
    }
}
