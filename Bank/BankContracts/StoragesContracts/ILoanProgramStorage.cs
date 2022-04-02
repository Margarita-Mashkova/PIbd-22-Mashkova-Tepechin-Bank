using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    internal interface ILoanProgramStorage
    {
        List<LoanProgramViewModel> GetFullList();

        List<LoanProgramViewModel> GetFilteredList(LoanProgramBindingModel model);

        LoanProgramViewModel GetElement(LoanProgramBindingModel model);

        void Insert(LoanProgramBindingModel model);

        void Update(LoanProgramBindingModel model);

        void Delete(LoanProgramBindingModel model);
    }
}
