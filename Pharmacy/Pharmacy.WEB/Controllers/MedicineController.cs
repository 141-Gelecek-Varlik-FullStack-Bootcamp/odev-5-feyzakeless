using Microsoft.AspNetCore.Mvc;
using Pharmacy.Model.ModelMedicine;
using Pharmacy.Service.MedicineServiceLayer;
using Pharmacy.Service.UserServiceLayer;

namespace Pharmacy.WEB.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService medicineService;

        public MedicineController( IMedicineService _medicineService)
        {
            medicineService = _medicineService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InsertMedicine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertMedicine(InsertMedicineViewModel newMedicine)
        {
            var model = medicineService.Insert(newMedicine);

            if (!model.IsSuccess)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateMedicine(int id)
        {
            var model = medicineService.GetById(id);
            return View(model.Entity);
        }

        [HttpPost]
         public IActionResult UpdateMedicine(UptadeMedicineViewModel medicine, int id)
         {
             var model = medicineService.Update(medicine , id);

             if (!model.IsSuccess)
             {
                 return View();
             }

             return RedirectToAction("Index", "Home");
         }


        [HttpPost]
         public IActionResult DeleteMedicine(int id)
         {
             medicineService.Delete(id);

            return RedirectToAction("Index", "Home");
         }
         
    }
}
