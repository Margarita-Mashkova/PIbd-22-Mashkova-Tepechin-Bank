using BankContracts.BindingModels;
using BankContracts.BusinessLogicsContracts;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportLogic _reportLogic;
        public ReportController(IReportLogic reportLogic)
        {
            _reportLogic = reportLogic;
        }

        [HttpPost]
        public void CreateReportClientCurrencyToWordFile(ReportBindingModel model) => _reportLogic.SaveClientCurrencyToWordFile(model);

        [HttpPost]
        public void CreateReportClientCurrencyToExcelFile(ReportBindingModel model) => _reportLogic.SaveClientCurrencyToExcelFile(model);

        [HttpPost]
        public void CreateReportClientsToPdfFile(ReportBindingModel model) => _reportLogic.SaveClientsToPdfFile(model);

        [HttpGet]
        public List<ReportClientsViewModel> GetClientsReport(string dateFrom, string dateTo) => _reportLogic.GetClients(new ReportBindingModel { DateFrom = Convert.ToDateTime(dateFrom), DateTo = Convert.ToDateTime(dateTo) });
    }
}
