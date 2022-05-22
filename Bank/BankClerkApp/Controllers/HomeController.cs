using BankClerkApp.Models;
using BankContracts.BindingModels;
using BankContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankClerkApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Clerk);
        }

        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClerk.PostRequest("api/clerk/updatedata", new ClerkBindingModel
                {
                    Id = Program.Clerk.Id,
                    ClerkFIO = fio,
                    Email = login,
                    Password = password
                });
                Program.Clerk.ClerkFIO = fio;
                Program.Clerk.Email = login;
                Program.Clerk.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Clerk = APIClerk.GetRequest<ClerkViewModel>($"api/clerk/login?login={login}&password={password}");
                if (Program.Clerk == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClerk.PostRequest("api/clerk/register", new ClerkBindingModel
                {
                    ClerkFIO = fio,
                    Email = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        public IActionResult Client()
        {
            return View(APIClerk.GetRequest<List<ClientViewModel>>("api/client/GetClientList"));
        }

        [HttpGet]
        public IActionResult ClientUpdate(int clientId)
        {
            ViewBag.Client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
            return View();
        }

        [HttpPost]
        public void ClientUpdate(int clientId, string clientFIO, string passport, string telephone)
        {
            if (!string.IsNullOrEmpty(clientFIO) && !string.IsNullOrEmpty(passport) && !string.IsNullOrEmpty(telephone))
            {
                var client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
                if (client == null)
                {
                    return;
                }
                APIClerk.PostRequest("api/client/CreateOrUpdateClient", new ClientBindingModel
                {
                    Id = client.Id,                    
                    ClientFIO = clientFIO,
                    PassportData = passport,
                    TelephoneNumber = telephone,
                    DateVisit = DateTime.Now,
                    ClientLoanPrograms = client.ClientLoanPrograms,
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
    }
}