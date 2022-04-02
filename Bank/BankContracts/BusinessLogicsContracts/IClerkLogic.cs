using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface IClerkLogic
    {
        List<ClerkViewModel> Read(ClerkBindingModel model);
        void CreateOrUpdate(ClerkBindingModel model);
        void Delete(ClerkBindingModel model);
    }
}
