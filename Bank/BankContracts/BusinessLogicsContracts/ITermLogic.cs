using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface ITermLogic
    {
        List<TermViewModel> Read(TermBindingModel model);
        void CreateOrUpdate(TermBindingModel model);
        void Delete(TermBindingModel model);
    }
}
