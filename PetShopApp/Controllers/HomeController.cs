using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;

namespace PetShopApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Animal>? _repository;
        public HomeController(IRepository<Animal>? repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            
            return View(_repository!.TwoMostPopular());
        }
    }
}
