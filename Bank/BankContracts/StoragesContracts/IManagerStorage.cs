using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface IManagerStorage
    {
        List<ManagerViewModel> GetFullList();

        List<ManagerViewModel> GetFilteredList(ManagerBindingModel model);

        ManagerViewModel GetElement(ManagerBindingModel model);

        void Insert(ManagerBindingModel model);

        void Update(ManagerBindingModel model);

        void Delete(ManagerBindingModel model);
    }
}
