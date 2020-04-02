using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilionarApp.Models;

namespace MilionarApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("Pepa8459", "Pepino!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "Uživatel už je zaregistrovaný!";

                AppUser user = await UserMgr.FindByNameAsync("Pepa8459");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "Pepa8459";
                    user.Email = "Pepa8459@test.com";
                    user.FirstName = "Pepa";
                    user.LastName = "Omacka";

                    IdentityResult result = await UserMgr.CreateAsync(user, "Pepino!");
                    ViewBag.Message = "Uživatel byl vytvořen!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

    }
}