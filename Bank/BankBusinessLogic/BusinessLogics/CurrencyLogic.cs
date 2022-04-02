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
    public class CurrencyLogic : ICurrencyLogic
    {
        private readonly ICurrencyStorage _currencyStorage;
        public CurrencyLogic(ICurrencyStorage currencyStorage)
        {
            _currencyStorage = currencyStorage;
        }

        public void CreateOrUpdate(CurrencyBindingModel model)
        {
            var currency = _currencyStorage.GetElement(new CurrencyBindingModel { CurrencyName = model.CurrencyName });
            if (currency != null && currency.Id != model.Id)
            {
                throw new Exception("Такая валюта уже есть");
            }
            if (model.Id.HasValue)
            {
                _currencyStorage.Update(model);
            }
            else
            {
                _currencyStorage.Insert(model);
            }
        }

        public void Delete(CurrencyBindingModel model)
        {
            var element = _currencyStorage.GetElement(new CurrencyBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _currencyStorage.Delete(model);
        }

        public List<CurrencyViewModel> Read(CurrencyBindingModel model)
        {
            if (model == null)
            {
                return _currencyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CurrencyViewModel> { _currencyStorage.GetElement(model) };
            }
            return _currencyStorage.GetFilteredList(model);
        }
    }
}
