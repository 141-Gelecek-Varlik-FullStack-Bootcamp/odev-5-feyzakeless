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

        //Kullanici ekleme(get)
        [HttpGet]
        public IActionResult InsertUser()
        {
           return View();
            
        }

        //Kullanici ekleme(post)
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

        //Kullanici listeleme
        public IActionResult ListUser()
        {
            return View(userService.GetUsers().List);
        }

        //Kullanici guncelleme(get)
        public IActionResult UpdateUser(int id)
        {
            var model  =userService.GetById(id);    
            return View(model.Entity);
        }

        //Kullanici guncelleme(post)
        [HttpPost]
        public IActionResult UpdateUser(UserViewModel user)
        {
            var model = userService.Update(user.Id, user);
            return RedirectToAction("UpdateUser", "User");
        }
    }
}
