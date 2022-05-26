using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReplenishmentController : ControllerBase
    {
        private readonly IReplenishmentLogic _replenishmentLogic;
        public ReplenishmentController(IReplenishmentLogic replenishmentLogic)
        {
            _replenishmentLogic = replenishmentLogic;
        }

        [HttpGet]
        public List<ReplenishmentViewModel> GetReplenishmentList() => _replenishmentLogic.Read(null)?.ToList();

        [HttpGet]
        public ReplenishmentViewModel GetReplenishment(int replenishmentId) => _replenishmentLogic.Read(new ReplenishmentBindingModel { Id = replenishmentId })?[0];

        [HttpPost]
        public void CreateOrUpdateReplenishment(ReplenishmentBindingModel model) => _replenishmentLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteReplenishment(ReplenishmentBindingModel model) => _replenishmentLogic.Delete(model);
    }
}
