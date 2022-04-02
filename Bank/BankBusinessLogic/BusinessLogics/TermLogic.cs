using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBusinessLogic.BusinessLogics
{
    public class TermLogic : ITermLogic
    {
        private readonly ITermStorage _termStorage;
        public TermLogic(ITermStorage termStorage)
        {
            _termStorage = termStorage;
        }
        public void CreateOrUpdate(TermBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _termStorage.Update(model);
            }
            else
            {
                _termStorage.Insert(model);
            }
        }

        public void Delete(TermBindingModel model)
        {
            var element = _termStorage.GetElement(new TermBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _termStorage.Delete(model);
        }

        public List<TermViewModel> Read(TermBindingModel model)
        {
            if (model == null)
            {
                return _termStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TermViewModel> { _termStorage.GetElement(model) };
            }
            return _termStorage.GetFilteredList(model);
        }
    }
}
