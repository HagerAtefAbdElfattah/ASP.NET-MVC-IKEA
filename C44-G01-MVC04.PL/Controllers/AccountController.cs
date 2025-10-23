using C44_G01_MVC04.DAL.Models.Identity;
using C44_G01_MVC04.PL.ViewModels.AccountVms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace C44_G01_MVC04.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var validUser = userManager.FindByNameAsync(registerViewModel.UserName).Result;
            if (validUser != null)
            {
                ModelState.AddModelError("", "Username is already taken");
                return View(registerViewModel);
            }
            var user = new ApplicationUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                FName = registerViewModel.FirstName,
                LName = registerViewModel.LastName
            };

            var result = userManager.CreateAsync(user, registerViewModel.Password).Result;
            if (result.Succeeded)
            { 
                return RedirectToAction(nameof(SignIn));
            }
            else {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerViewModel);
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
