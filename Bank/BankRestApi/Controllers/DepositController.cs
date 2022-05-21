using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositLogic _depositLogic;
        public DepositController(IDepositLogic depositLogic)
        {
            _depositLogic = depositLogic;
        }

        [HttpGet]
        public List<DepositViewModel> GetDepositList() => _depositLogic.Read(null)?.ToList();

        [HttpGet]
        public DepositViewModel GetDeposit(int depositId) => _depositLogic.Read(new DepositBindingModel { Id = depositId })?[0];

        [HttpPost]
        public void CreateOrUpdateDeposit(DepositBindingModel model) => _depositLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteDeposit(DepositBindingModel model) => _depositLogic.Delete(model);
    }
}
