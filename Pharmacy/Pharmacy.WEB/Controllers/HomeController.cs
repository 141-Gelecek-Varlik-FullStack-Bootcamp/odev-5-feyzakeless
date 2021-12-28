using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pharmacy.Model.ModelLogin;
using Pharmacy.Service.MedicineServiceLayer;
using Pharmacy.Service.UserServiceLayer;
using Pharmacy.WEB.Models;
using System.Diagnostics;

namespace Pharmacy.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IMedicineService medicineService;

        public HomeController(ILogger<HomeController> logger, IUserService _userService, IMedicineService _medicineService)
        {
            _logger = logger;
            userService = _userService;
            medicineService = _medicineService;    
        }

       
        public IActionResult Index()
        {
            var model = medicineService.GetList().List;
            return View(model);
        }

        
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginUser)
        {
            var model = userService.Login(loginUser);

            if (!model.IsSuccess)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
