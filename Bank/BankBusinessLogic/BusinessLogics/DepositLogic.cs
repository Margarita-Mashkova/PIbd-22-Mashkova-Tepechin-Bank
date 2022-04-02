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
    public class DepositLogic :IDepositLogic
    {
        private readonly IDepositStorage _depositStorage;
        public DepositLogic(IDepositStorage depositStorage)
        {
            _depositStorage = depositStorage;
        }
        public List<DepositViewModel> Read(DepositBindingModel model)
        {
            if (model == null)
            {
                return _depositStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DepositViewModel> { _depositStorage.GetElement(model) };
            }
            return _depositStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DepositBindingModel model)
        {
            var element = _depositStorage.GetElement(new DepositBindingModel
            {
                DepositName = model.DepositName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть вклад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _depositStorage.Update(model);
            }
            else
            {
                _depositStorage.Insert(model);
            }
        }
        public void Delete(DepositBindingModel model)
        {
            var element = _depositStorage.GetElement(new DepositBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _depositStorage.Delete(model);
        }
    }
}
