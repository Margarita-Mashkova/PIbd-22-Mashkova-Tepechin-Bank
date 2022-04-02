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
    public class ManagerLogic : IManagerLogic
    {
        private readonly IManagerStorage _managerStorage;
        public ManagerLogic (IManagerStorage managerStorage)
        {
            _managerStorage = managerStorage;
        }
        public void CreateOrUpdate(ManagerBindingModel model)
        {
            var loanProgram = _managerStorage.GetElement(new ManagerBindingModel { Email = model.Email });
            if (loanProgram != null && loanProgram.Id != model.Id)
            {
                throw new Exception("Такая такой руководитель уже существуют");
            }
            if (model.Id.HasValue)
            {
                _managerStorage.Update(model);
            }
            else
            {
                _managerStorage.Insert(model);
            }
        }

        public void Delete(ManagerBindingModel model)
        {
            var element = _managerStorage.GetElement(new ManagerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _managerStorage.Delete(model);
        }

        public List<ManagerViewModel> Read(ManagerBindingModel model)
        {
            if (model == null)
            {
                return _managerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ManagerViewModel> { _managerStorage.GetElement(model) };
            }
            return _managerStorage.GetFilteredList(model);
        }
    }
}
