using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;

namespace BankBusinessLogic.BusinessLogics
{
    public class ClerkLogic : IClerkLogic
    {
        private readonly IClerkStorage _clerkStorage;
        public ClerkLogic(IClerkStorage clerkStorage)
        {
            _clerkStorage = clerkStorage;
        }
        public List<ClerkViewModel> Read(ClerkBindingModel model)
        {
            if (model == null)
            {
                return _clerkStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClerkViewModel> { _clerkStorage.GetElement(model) };
            }
            return _clerkStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ClerkBindingModel model)
        {
            var element = _clerkStorage.GetElement(new ClerkBindingModel
            {
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть клерк с таким логином");
            }
            if (model.Id.HasValue)
            {
                _clerkStorage.Update(model);
            }
            else
            {
                _clerkStorage.Insert(model);
            }
        }
        public void Delete(ClerkBindingModel model)
        {
            var element = _clerkStorage.GetElement(new ClerkBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _clerkStorage.Delete(model);
        }
    }
}
