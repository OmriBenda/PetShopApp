using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;

namespace PetShopApp.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Animal>? _repository;
        public AdminController(IRepository<Animal>? repository)
        {
            _repository = repository;
        }
        public IActionResult SelectAnimal(int id)
        {
            ViewBag.ListOfCategories = _repository!.GetCategoryNames();
            if (id == 0)
            {
                return View(_repository!.GetAnimals());
            }
            else
                return View(_repository.ByCategory(id));
        }
        public IActionResult DeleteAnimal(int id)
        {
            _repository!.DeleteAnimal(id);
            return RedirectToAction("SelectAnimal");
        }

        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            ViewBag.ListOfCategories = _repository!.GetCategoryNames();
            return View(_repository.GetAnimalById(id));
        }

        [HttpPost]
        public IActionResult EditAnimal(int id, Animal animal)
        {
            if (ModelState.IsValid)
            {
               animal.PictureName = "~/images/" + animal.PictureName;
               _repository!.UpdateAnimal(id, animal);
               return RedirectToAction("SelectAnimal");
            }
            else
             return EditAnimal(id);
        }

        [HttpGet]
        public IActionResult CreateAnimal()
        {
            ViewBag.ListOfCategories = _repository!.GetCategoryNames();
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            ViewBag.ListOfCategories = _repository!.GetCategoryNames();
            if (ModelState.IsValid)
            {
                animal.PictureName = "~/images/" + animal.PictureName;
                _repository.InsertAnimal(animal);
                return RedirectToAction("SelectAnimal");
            }
            else
                return View("CreateAnimal");

        }
    }
}
