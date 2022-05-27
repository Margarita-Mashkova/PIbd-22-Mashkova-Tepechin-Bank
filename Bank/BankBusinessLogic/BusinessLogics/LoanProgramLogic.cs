using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.StoragesContracts;
using BankContracts.ViewModels;

namespace BankBusinessLogic.BusinessLogics
{
    public class LoanProgramLogic : ILoanProgramLogic
    {
        private readonly ILoanProgramStorage _loanProgramStorage;
        public LoanProgramLogic (ILoanProgramStorage loanProgramStorage)
        {
            _loanProgramStorage = loanProgramStorage;
        }
        public void CreateOrUpdate(LoanProgramBindingModel model)
        {
            var loanProgram = _loanProgramStorage.GetElement(new LoanProgramBindingModel { LoanProgramName = model.LoanProgramName });
            if (loanProgram != null && loanProgram.Id != model.Id)
            {
                throw new Exception("Такая кредитная программа уже есть");
            }
            if (model.Id.HasValue)
            {
                _loanProgramStorage.Update(model);
            }
            else
            {
                _loanProgramStorage.Insert(model);
            }
        }

        public void Delete(LoanProgramBindingModel model)
        {
            var element = _loanProgramStorage.GetElement(new LoanProgramBindingModel{ Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _loanProgramStorage.Delete(model);
        }

        public List<LoanProgramViewModel> Read(LoanProgramBindingModel model)
        {
            if (model == null)
            {
                return _loanProgramStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LoanProgramViewModel> { _loanProgramStorage.GetElement(model) };
            }
            return _loanProgramStorage.GetFilteredList(model);
        }
    }
}
