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
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = userManager.FindByEmailAsync(loginViewModel.Email).Result;
            
            if (user != null)
            {
                var isValid = signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true).Result;
                if (isValid.IsNotAllowed)
                {
                    ModelState.AddModelError("", "You are not allowed to sign in");
                }
                if (isValid.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account is locked");
                }
                if (isValid.Succeeded)
                {
                    return RedirectToAction((nameof(HomeController.Index)), "Home");
                }
            }
            ModelState.AddModelError("", "Invalid Email or Password");
            return View(loginViewModel);
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
