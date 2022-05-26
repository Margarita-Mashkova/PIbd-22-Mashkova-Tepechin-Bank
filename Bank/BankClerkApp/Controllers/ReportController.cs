using BankBusinessLogic.Mail;
using BankContracts.BindingModels;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BankClerkApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly MailKitWorker _mailKitWorker;

        public ReportController(ILogger<ReportController> logger, IWebHostEnvironment environment, MailKitWorker mailKitWorker)
        {
            _logger = logger;
            _environment = environment;
            _mailKitWorker = mailKitWorker;
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
            if (clientsId != null)
            {
                var model = new ReportBindingModel
                {
                    Clients = new List<ClientViewModel>(),
                    LoanPrograms = new List<LoanProgramViewModel>()
                };
                foreach (var clientId in clientsId)
                {
                    model.Clients.Add(APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}"));
                }
                model.FileName = @"..\BankClerkApp\wwwroot\ReportClientCurrency\ReportClientCurrencyDoc.doc";
                APIClerk.PostRequest("api/report/CreateReportClientCurrencyToWordFile", model);
                var fileName = "ReportClientCurrencyDoc.doc";
                var filePath = _environment.WebRootPath + @"\ReportClientCurrency\" + fileName;
                return Redirect("ReportWordExcel");
                //Response.Redirect(PhysicalFile(filePath, "application/doc", fileName));
            }
            throw new Exception("Выберите хотя бы одного клиента");
        }

        [HttpPost]
        public IActionResult CreateReportClientCurrencyToExcelFile(List<int> clientsId)
        {
            if (clientsId != null)
            {
                var model = new ReportBindingModel
                {
                    Clients = new List<ClientViewModel>(),
                    LoanPrograms = new List<LoanProgramViewModel>()
                };
                foreach (var clientId in clientsId)
                {
                    model.Clients.Add(APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}"));
                }
                model.FileName = @"..\BankClerkApp\wwwroot\ReportClientCurrency\ReportClientCurrencyExcel.xls";
                APIClerk.PostRequest("api/report/CreateReportClientCurrencyToExcelFile", model);
                var fileName = "ReportClientCurrencyExcel.xls";
                var filePath = _environment.WebRootPath + @"\ReportClientCurrency\" + fileName;
                return PhysicalFile(filePath, "application/xls", fileName);
            }
            throw new Exception("Выберите хотя бы одного клиента");
        }

        public IActionResult ReportPDF()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ReportGetClientsPDF(DateTime dateFrom, DateTime dateTo)
        {
            ViewBag.Period = "C " + dateFrom.ToLongDateString() + " по " + dateTo.ToLongDateString();
            ViewBag.Report = APIClerk.GetRequest<List<ReportClientsViewModel>>($"api/report/GetClientsReport?dateFrom={dateFrom.ToLongDateString()}&dateTo={dateTo.ToLongDateString()}");
            return View("ReportPdf");
        }

        [HttpPost]
        public IActionResult SendReportOnMail(DateTime dateFrom, DateTime dateTo)
        {
            var model = new ReportBindingModel
            {
                DateFrom = dateFrom,
                DateTo = dateTo
            };
            model.FileName = @"..\BankClerkApp\wwwroot\ReportClientCurrency\ReportClientsPdf.pdf";
            APIClerk.PostRequest("api/report/CreateReportClientsToPdfFile", model);
            _mailKitWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = Program.Clerk.Email,
                Subject = "Отчет по клиентам. Банк \"Вы банкрот\"",
                Text = "Отчет по клиентам с " + dateFrom.ToShortDateString() + " по " + dateTo.ToShortDateString() +
                "\nРуководитель - " + Program.Clerk.ClerkFIO,
                FileName = model.FileName,
            });
            return View();
        }
    }
}
