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
        private readonly IClerkLogic _logic;
        public ClerkController(IClerkLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ClerkViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClerkBindingModel
            {
                Email = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClerkBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClerkBindingModel model) => _logic.CreateOrUpdate(model);
    }
}

