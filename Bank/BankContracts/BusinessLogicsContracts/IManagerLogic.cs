using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IManagerLogic
    {
        List<ManagerViewModel> Read(ManagerBindingModel model);
        void CreateOrUpdate(ManagerBindingModel model);
        void Delete(ManagerBindingModel model);
    }
}
