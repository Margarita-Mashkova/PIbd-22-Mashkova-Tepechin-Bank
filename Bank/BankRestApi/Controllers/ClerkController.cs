using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClerkController : ControllerBase
    {
        private readonly IClerkLogic _clerkLogic;
        private readonly IDepositLogic _depositLogic;
        private readonly IReplenishmentLogic _replenishmentLogic;
        private readonly IClientLogic _clientLogic;
        public ClerkController(IClerkLogic logic, IDepositLogic depositLogic, IReplenishmentLogic replenishmentLogic, IClientLogic clientLogic)
        {
            _clerkLogic = logic;
            _depositLogic = depositLogic;
            _replenishmentLogic = replenishmentLogic;
            _clientLogic = clientLogic;
        }

        [HttpGet]
        public ClerkViewModel Login(string login, string password)
        {
            var list = _clerkLogic.Read(new ClerkBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClerkBindingModel model) => _clerkLogic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClerkBindingModel model) => _clerkLogic.CreateOrUpdate(model);

        [HttpGet]
        public List<DepositViewModel> GetClerkDepositList(int clerkId) => _depositLogic.Read(new DepositBindingModel { ClerkId = clerkId });

        [HttpGet]
        public List<ClientViewModel> GetClerkClientList(int clerkId) => _clientLogic.Read(new ClientBindingModel { ClerkId = clerkId });

        [HttpGet]
        public List<ReplenishmentViewModel> GetClerkReplenishmentList(int clerkId) => _replenishmentLogic.Read(new ReplenishmentBindingModel { ClerkId = clerkId });
    }
}

