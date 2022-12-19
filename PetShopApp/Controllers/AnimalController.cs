using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;

namespace PetShopApp.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository<Animal>? _repository;
        public AnimalController(IRepository<Animal>? repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ShowDetails(int id)
        {
            return View(_repository!.GetAnimalById(id));
        }

        [HttpPost]
        public IActionResult ShowDetails(int id, string commen)
        {
            if (ModelState.IsValid)
            {
                _repository!.AddComment(id, commen);
                return View(_repository!.GetAnimalById(id));
            }
            else
                return RedirectToAction("ShowDetails", id);
        }
    }
}
