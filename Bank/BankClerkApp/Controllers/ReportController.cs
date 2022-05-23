using BankContracts.BindingModels;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankClerkApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ReportController(ILogger<ReportController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult ReportWordExcel()
        {            
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Clients = APIClerk.GetRequest<List<ClientViewModel>>($"api/clerk/GetClerkClientList?clerkId={Program.Clerk.Id}");
            return View();
        }

        [HttpPost]
        public IActionResult CreateReportClientCurrencyToWordFile(List<int> clientsId)
        {
            var model = new ReportBindingModel();
            foreach (var clientId in clientsId)
            {
                var client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
                model.Clients.Add(client);
            }
            model.FileName = @"..\BankClerkApp\wwwroot\ReportClientCurrency\ReportClientCurrencyDoc.doc";
            APIClerk.PostRequest("api/report/CreateReportClientCurrencyToWordFile", model);
            var fileName = "ReportClientCurrencyDoc.doc";
            var filePath = _environment.WebRootPath + @"\ReportClientCurrency\" + fileName;
            return PhysicalFile(filePath, "application/doc", fileName);
        }

        public IActionResult ReportPDF()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }        
    }
}
