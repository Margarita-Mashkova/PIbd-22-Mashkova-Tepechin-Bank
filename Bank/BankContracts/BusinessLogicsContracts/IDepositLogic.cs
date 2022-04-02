using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IDepositLogic
    {
        List<DepositViewModel> Read(DepositBindingModel model);
        void CreateOrUpdate(DepositBindingModel model);
        void Delete(DepositBindingModel model);
    }
}
