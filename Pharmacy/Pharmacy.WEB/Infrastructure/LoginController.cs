using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.WEB.Infrastructure
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
