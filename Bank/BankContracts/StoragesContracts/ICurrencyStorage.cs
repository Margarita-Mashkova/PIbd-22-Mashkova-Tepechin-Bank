using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface ICurrencyStorage
    {
        List<CurrencyViewModel> GetFullList();

        List<CurrencyViewModel> GetFilteredList(CurrencyBindingModel model);

        CurrencyViewModel GetElement(CurrencyBindingModel model);

        void Insert(CurrencyBindingModel model);

        void Update(CurrencyBindingModel model);

        void Delete(CurrencyBindingModel model);
    }
}
