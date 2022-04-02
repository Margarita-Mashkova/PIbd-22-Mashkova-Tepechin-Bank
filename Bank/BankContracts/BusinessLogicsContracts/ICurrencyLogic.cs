using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface ICurrencyLogic
    {
        List<CurrencyViewModel> Read(CurrencyBindingModel model);
        void CreateOrUpdate(CurrencyBindingModel model);
        void Delete(CurrencyBindingModel model);
    }
}
