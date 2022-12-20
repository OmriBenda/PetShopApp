using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


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
            ClaimsPrincipal claimsUser = HttpContext.User;
            if(claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("SelectAnimal", "Admin");

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(Login login)
        {
            if (_repository.CheckValid(login) && ModelState.IsValid)
            {
                List<Claim> claims = new List<Claim>() {
                  new Claim(ClaimTypes.NameIdentifier, login.Name)
                };
                ClaimsIdentity ClaimsIdentity = new ClaimsIdentity(claims, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = login.KeepLoggedIn
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(ClaimsIdentity),properties);
                return RedirectToAction("SelectAnimal", "Admin");
            }
            return View("Login");
        }
    }
}
