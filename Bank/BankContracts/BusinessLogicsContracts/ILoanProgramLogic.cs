using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.BusinessLogicsContracts
{
    public interface ILoanProgramLogic
    {
        List<LoanProgramViewModel> Read(LoanProgramBindingModel model);
        void CreateOrUpdate(LoanProgramBindingModel model);
        void Delete(LoanProgramBindingModel model);
    }
}
