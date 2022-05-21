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
        public ClientController(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }

        [HttpGet]
        public List<ClientViewModel> GetClientList() => _clientLogic.Read(null)?.ToList();

        [HttpGet]
        public ClientViewModel GetClient(int clientId) => _clientLogic.Read(new ClientBindingModel { Id = clientId })?[0];

        [HttpPost]
        public void CreateOrUpdateClient(ClientBindingModel model) => _clientLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteClient(ClientBindingModel model) => _clientLogic.Delete(model);
    }
}
