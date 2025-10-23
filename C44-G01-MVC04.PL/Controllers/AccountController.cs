using C44_G01_MVC04.DAL.Models.Emails;
using C44_G01_MVC04.DAL.Models.Identity;
using C44_G01_MVC04.PL.Helpers;
using C44_G01_MVC04.PL.ViewModels.AccountVms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
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
            else
            {
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

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPasswordViewModel);
            }
            var user = userManager.FindByEmailAsync(forgetPasswordViewModel.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email");
                return View(forgetPasswordViewModel);
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = forgetPasswordViewModel.Email, token = token }, Request.Scheme);
            var email = new Email()
            {
                To = forgetPasswordViewModel.Email,
                Subject = "Password Reset",
                Body = passwordResetLink,
                SentDate = DateTime.Now
            };
            EmailSettings.SendEmail(email);
            return RedirectToAction(nameof(CheckYourInbox));
        }

        public IActionResult CheckYourInbox()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
           var resetPasswordViewModel = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };
            return View(resetPasswordViewModel);    
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }
            var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email");
                return View(resetPasswordViewModel);
            }
            var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.NewPassword);
            if (result.Succeeded)
            {
              return RedirectToAction(nameof(SignIn));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(resetPasswordViewModel);
        }
    }
}
