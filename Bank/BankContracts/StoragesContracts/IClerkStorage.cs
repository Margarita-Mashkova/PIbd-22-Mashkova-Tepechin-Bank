using BankContracts.BindingModels;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankContracts.StoragesContracts
{
    public interface IClerkStorage
    {
        List<ClerkViewModel> GetFullList();

        List<ClerkViewModel> GetFilteredList(ClerkBindingModel model);

        ClerkViewModel GetElement(ClerkBindingModel model);

        void Insert(ClerkBindingModel model);

        void Update(ClerkBindingModel model);

        void Delete(ClerkBindingModel model);
    }
}
