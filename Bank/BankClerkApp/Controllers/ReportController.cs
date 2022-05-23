using Microsoft.AspNetCore.Mvc;

namespace BankClerkApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        public IActionResult ReportWord()
        {            
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        public IActionResult ReportExcel()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
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
