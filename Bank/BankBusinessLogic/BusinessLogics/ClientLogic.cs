using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;

namespace BankBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientStorage _clientStorage;       
        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel
            {
                PassportData = model.PassportData
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть клиент с такими паспортными данными");
            }
            if (!Regex.IsMatch(model.ClientFIO, @"([А-ЯЁ][а-яё]+[\-\s]?){3,}"))
            {
                throw new Exception("ФИО указано в неверном формате");
            }
            if (!Regex.IsMatch(model.TelephoneNumber, @"^((\+7|7|8)+([0-9]){10})$"))
            {
                throw new Exception("Введён неверный формат номера телефона");
            }
            if (!Regex.IsMatch(model.PassportData, @"\d{4}\s\d{6}"))
            {
                throw new Exception("Введён неверный формат паспортных данных");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }
        public void Delete(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
