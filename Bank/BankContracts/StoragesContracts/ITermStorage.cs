using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface ITermStorage
    {
        List<TermViewModel> GetFullList();

        List<TermViewModel> GetFilteredList(TermBindingModel model);

        TermViewModel GetElement(TermBindingModel model);

        void Insert(TermBindingModel model);

        void Update(TermBindingModel model);

        void Delete(TermBindingModel model);
    }
}
