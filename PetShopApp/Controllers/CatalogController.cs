using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;

namespace PetShopApp.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository<Animal>? _repository;
        public CatalogController(IRepository<Animal>? repository)
        {
            _repository = repository;
        }
        public IActionResult Catalog(int id)
        {
            ViewBag.ListOfCategories = _repository!.GetCategoryNames();
            if (id == 0)
            {
                return View(_repository.GetAnimals());
            }
            else
                return View(_repository!.ByCategory(id));
        }
    }
}
