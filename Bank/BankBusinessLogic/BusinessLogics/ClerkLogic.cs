using System.Text.RegularExpressions;
using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;

namespace BankBusinessLogic.BusinessLogics
{
    public class ClerkLogic : IClerkLogic
    {
        private readonly IClerkStorage _clerkStorage;
        private readonly int _emailMaxLength = 50;
        private readonly int _passwordMaxLength = 30;
        private readonly int _passwordMinLength = 10;
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
            if (model.Email.Length > _emailMaxLength || !Regex.IsMatch(model.Email, @"([a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+)"))
            {
                throw new Exception($"В качестве логина должна быть указана почта и иметь длинну не более {_emailMaxLength} символов");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength 
                || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен состоять из цифр, букв и небуквенных символов");
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
