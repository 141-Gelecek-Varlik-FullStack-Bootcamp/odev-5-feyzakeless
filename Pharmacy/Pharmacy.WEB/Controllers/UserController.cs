using Microsoft.AspNetCore.Mvc;
using Pharmacy.Model.ModelUser;
using Pharmacy.Service.UserServiceLayer;

namespace Pharmacy.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertUser()
        {
           return View();
            
        }

        [HttpPost]
        public IActionResult InsertUser(UserViewModel newUser)
        {
            var model = userService.Insert(newUser);

            if (!model.IsSuccess)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult ListUser()
        {
            return View(userService.GetUsers().List);
        }

        public IActionResult UpdateUser(int id)
        {
            var model  =userService.GetById(id);    
            return View(model.Entity);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserViewModel user)
        {
            var model = userService.Update(user.Id, user);
            return RedirectToAction("UpdateUser", "User");
        }
    }
}
