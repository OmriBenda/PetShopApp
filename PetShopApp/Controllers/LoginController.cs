using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;

namespace PetShopApp.Controllers
{
    public class LoginController : Controller
    {
        private IRepository<Animal> _repository;
        public LoginController(IRepository<Animal> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (_repository.CheckValid(login) && ModelState.IsValid)
            {
                return RedirectToAction("SelectAnimal", "Admin");
            }
            return View("Login");
        }
    }
}
