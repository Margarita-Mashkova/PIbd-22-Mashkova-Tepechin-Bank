﻿using BankClerkApp.Models;
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
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClerk.GetRequest<List<ClientViewModel>>($"api/clerk/GetClerkClientList?clerkId={Program.Clerk.Id}"));
        }

        [HttpGet]
        public IActionResult ClientCreate()
        {
            ViewBag.LoanPrograms = APIClerk.GetRequest<List<LoanProgramViewModel>>("api/client/GetLoanProgramList");
            return View();
        }

        [HttpPost]
        public void ClientCreate(string clientFIO, string passport, string telephone, List<int> loanProgramsId)
        {
            List<LoanProgramViewModel> loanPrograms = new List<LoanProgramViewModel>();
            foreach (var loanProgramId in loanProgramsId)
            {
                loanPrograms.Add(APIClerk.GetRequest<LoanProgramViewModel>($"api/client/GetLoanProgram?loanProgramId={loanProgramId}"));
            }            
            if (!string.IsNullOrEmpty(clientFIO) && !string.IsNullOrEmpty(passport) && !string.IsNullOrEmpty(telephone) && loanPrograms!=null)
            {
                APIClerk.PostRequest("api/client/CreateOrUpdateClient", new ClientBindingModel
                {
                    ClientFIO = clientFIO,
                    PassportData = passport,        
                    TelephoneNumber = telephone,
                    DateVisit = DateTime.Now,
                    ClientLoanPrograms = loanPrograms.ToDictionary(x => x.Id, x => x.LoanProgramName),
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Client");
                return;
            }
            throw new Exception("Введите ФИО, паспортные данные и номер телефона");
        }

        [HttpGet]
        public IActionResult ClientUpdate(int clientId)
        {
            ViewBag.Client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
            ViewBag.LoanPrograms = APIClerk.GetRequest<List<LoanProgramViewModel>>("api/client/GetLoanProgramList");
            var Deposits = APIClerk.GetRequest<List<DepositViewModel>>("api/deposit/GetDepositList");
            var clientDeposits = new List<DepositViewModel>();
            foreach (var dep in Deposits)
            {
                if (dep.DepositClients.ContainsKey(clientId))
                {
                    clientDeposits.Add(dep);
                }
            }
            ViewBag.ClientDeposits = clientDeposits;
            return View();
        }

        [HttpPost]
        public void ClientUpdate(int clientId, string clientFIO, string passport, string telephone, List<int> loanProgramsId)
        {
            if (!string.IsNullOrEmpty(clientFIO) && !string.IsNullOrEmpty(passport) && !string.IsNullOrEmpty(telephone) && loanProgramsId!=null)
            {
                var client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
                if (client == null)
                {
                    return;
                }
                List<LoanProgramViewModel> loanPrograms = new List<LoanProgramViewModel>();
                foreach (var loanProgramId in loanProgramsId)
                {
                    loanPrograms.Add(APIClerk.GetRequest<LoanProgramViewModel>($"api/client/GetLoanProgram?loanProgramId={loanProgramId}"));
                }
                APIClerk.PostRequest("api/client/CreateOrUpdateClient", new ClientBindingModel
                {
                    Id = client.Id,
                    ClientFIO = clientFIO,
                    PassportData = passport,
                    TelephoneNumber = telephone,
                    DateVisit = DateTime.Now,
                    ClientLoanPrograms = loanPrograms.ToDictionary(x => x.Id, x => x.LoanProgramName),
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Client");
                return;
            }
            throw new Exception("Введите ФИО, паспортные данные, номер телефона и выберите кредитную программу");
        }

        [HttpGet]
        public void ClientDelete(int clientId)
        {
            var client = APIClerk.GetRequest<ClientViewModel>($"api/client/GetClient?clientId={clientId}");
            APIClerk.PostRequest("api/client/DeleteClient", client);
            Response.Redirect("Client");
        }

        public IActionResult Deposit()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClerk.GetRequest<List<DepositViewModel>>($"api/clerk/GetClerkDepositList?clerkId={Program.Clerk.Id}"));
        }

        [HttpGet]
        public IActionResult DepositCreate()
        {
            return View();
        }

        [HttpPost]
        public void DepositCreate(string depositName, decimal depositInterest)
        {
            if (!string.IsNullOrEmpty(depositName))
            {
                APIClerk.PostRequest("api/deposit/CreateOrUpdateDeposit", new DepositBindingModel
                {
                    DepositName = depositName,
                    DepositInterest = depositInterest,
                    DepositClients = new Dictionary<int, string>(),
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Deposit");
                return;
            }
            throw new Exception("Введите наименование вклада и процентную ставку");
        }

        [HttpGet]
        public IActionResult DepositUpdate(int depositId)
        {
            ViewBag.Deposit = APIClerk.GetRequest<DepositViewModel>($"api/deposit/GetDeposit?depositId={depositId}");
            return View();
        }

        [HttpPost]
        public void DepositUpdate(int depositId, string depositName, decimal depositInterest)
        {
            if (!string.IsNullOrEmpty(depositName) && depositInterest != 0)
            {
                var deposit = APIClerk.GetRequest<DepositViewModel>($"api/deposit/GetDeposit?depositId={depositId}");
                if (deposit == null)
                {
                    return;
                }
                APIClerk.PostRequest("api/deposit/CreateOrUpdateDeposit", new DepositBindingModel
                {
                    Id = deposit.Id,
                    DepositName = depositName,
                    DepositInterest = depositInterest,
                    DepositClients = deposit.DepositClients,
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Deposit");
                return;
            }
            throw new Exception("Введите наименование вклада и процентную ставку");
        }

        [HttpGet]
        public void DepositDelete(int depositId)
        {
            var deposit = APIClerk.GetRequest<DepositViewModel>($"api/deposit/GetDeposit?depositId={depositId}");
            APIClerk.PostRequest("api/deposit/DeleteDeposit", deposit);
            Response.Redirect("Deposit");
        }

        public IActionResult Replenishment()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClerk.GetRequest<List<ReplenishmentViewModel>>($"api/clerk/GetClerkReplenishmentList?clerkId={Program.Clerk.Id}"));
        }

        [HttpGet]
        public IActionResult ReplenishmentCreate()
        {
            ViewBag.Deposits = APIClerk.GetRequest<List<DepositViewModel>>("api/deposit/GetDepositList");
            return View();
        }

        [HttpPost]
        public void ReplenishmentCreate(int replenishmentAmount, int depositId)
        {
            if (replenishmentAmount!=0 && depositId!=0)
            {
                APIClerk.PostRequest("api/replenishment/CreateOrUpdateReplenishment", new ReplenishmentBindingModel
                {
                    Amount = replenishmentAmount,
                    DateReplenishment = DateTime.Now,
                    DepositId = depositId,
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Replenishment");
                return;
            }
            throw new Exception("Введите сумму пополнения и выберите вклад");
        }

        [HttpGet]
        public IActionResult ReplenishmentUpdate(int replenishmentId)
        {
            ViewBag.Deposits = APIClerk.GetRequest<List<DepositViewModel>>("api/deposit/GetDepositList");
            ViewBag.Replenishment = APIClerk.GetRequest<ReplenishmentViewModel>($"api/replenishment/GetReplenishment?replenishmentId={replenishmentId}");
            return View();
        }

        [HttpPost]
        public void ReplenishmentUpdate(int replenishmentId, int replenishmentAmount, int depositId)
        {
            if (replenishmentAmount!=0 && replenishmentAmount != 0 && depositId!=0)
            {
                var replenishment = APIClerk.GetRequest<ReplenishmentViewModel>($"api/replenishment/GetReplenishment?replenishmentId={replenishmentId}");
                if (replenishment == null)
                {
                    return;
                }
                APIClerk.PostRequest("api/replenishment/CreateOrUpdateReplenishment", new ReplenishmentBindingModel
                {
                    Id = replenishment.Id,
                    Amount = replenishmentAmount,
                    DateReplenishment = DateTime.Now,
                    DepositId = depositId,
                    ClerkId = Program.Clerk.Id
                });
                Response.Redirect("Replenishment");
                return;
            }
            throw new Exception("Введите сумму пополнения и выберите вклад");
        }

        [HttpGet]
        public void ReplenishmentDelete(int replenishmentId)
        {
            var replenishment = APIClerk.GetRequest<ReplenishmentViewModel>($"api/replenishment/GetReplenishment?replenishmentId={replenishmentId}");
            APIClerk.PostRequest("api/replenishment/DeleteReplenishment", replenishment);
            Response.Redirect("Replenishment");
        }

        [HttpGet]
        public IActionResult AddDepositClients()
        {
            if (Program.Clerk == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Deposits = APIClerk.GetRequest<List<DepositViewModel>>("api/deposit/GetDepositList");
            ViewBag.Clients = APIClerk.GetRequest<List<ClientViewModel>>($"api/clerk/GetClerkClientList?clerkId={Program.Clerk.Id}");
            return View();
        }

        [HttpPost]
        public void AddDepositClients(int depositId, List<int> clientsId)
        {
            if(depositId!=0 && clientsId != null)
            {
                APIClerk.PostRequest("api/deposit/AddDepositClients", new AddClientsBindingModel
                {
                    DepositId = depositId,
                    ClientsId = clientsId
                });
                Response.Redirect("Deposit");
                return;
            }
            throw new Exception("Выберите вклад и клиентов");
        }
    }
}