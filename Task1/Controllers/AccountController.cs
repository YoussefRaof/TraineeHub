using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Task01.Models;
using Task01.ViewModels;

namespace Task01.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel UserToRegister)
        {
            if (UserToRegister is not null)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser appuser = new ApplicationUser();
                    appuser.UserName = UserToRegister.UserName;
                    appuser.Address = UserToRegister.Address;
                    appuser.PasswordHash = UserToRegister.Password;
                    //Save To Database  

                    IdentityResult result = await _userManager.CreateAsync(appuser, UserToRegister.Password);

                    if (result.Succeeded)
                    {
                        //Create Cookie
                        await _signInManager.SignInAsync(appuser, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }


                return View(UserToRegister);


            }
            return View(UserToRegister);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel UserToLogin)
        {
            if (UserToLogin is not null)
            {
                if (ModelState.IsValid)
                {
                    //Check IS Found Or Not
                    ApplicationUser user = await _userManager.FindByNameAsync(UserToLogin.UserName);

                    if(user is not null)
                    {
                        bool found = await _userManager.CheckPasswordAsync(user,UserToLogin.Password);
                        if (found)
                        {
                            await _signInManager.SignInAsync(user, UserToLogin.RememberMe);
                            return RedirectToAction("Index", "Trainee");
                        }
                    }


                }
                ModelState.AddModelError("", "Wrong UserName Or Passsword!!!!!");
                return View(UserToLogin);
            }

            return View(UserToLogin);
        }
        public IActionResult Signout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
