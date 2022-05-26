using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _clientLogic;
        private readonly ILoanProgramLogic _loanProgramLogic;
        
        public ClientController(IClientLogic clientLogic, ILoanProgramLogic loanProgramLogic)
        {
            _clientLogic = clientLogic;
            _loanProgramLogic = loanProgramLogic;
        }

        [HttpGet]
        public List<ClientViewModel> GetClientList() => _clientLogic.Read(null)?.ToList();

        [HttpGet]
        public List<LoanProgramViewModel> GetLoanProgramList() => _loanProgramLogic.Read(null)?.ToList();

        [HttpGet]
        public LoanProgramViewModel GetLoanProgram(int loanProgramId) => _loanProgramLogic.Read(new LoanProgramBindingModel { Id = loanProgramId })?[0];

        [HttpGet]
        public ClientViewModel GetClient(int clientId) => _clientLogic.Read(new ClientBindingModel { Id = clientId })?[0];

        [HttpPost]
        public void CreateOrUpdateClient(ClientBindingModel model) => _clientLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteClient(ClientBindingModel model) => _clientLogic.Delete(model);        
    }
}
