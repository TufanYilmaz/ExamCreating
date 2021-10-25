using EntityLayer.Concrete;
using ExamMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamMvc.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        BusinessLayer.Concrete.UserManager userManager = new BusinessLayer.Concrete.UserManager();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user, string ReturnUrl)
        {
            var tUser = userManager.GetUserByName(user.Username);
            
            if (tUser != null)
            {
                if (tUser.Password == user.Password.ToString())
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
                    var claimIdentity = new ClaimsIdentity(claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                    HttpContext.Session.SetString("username", tUser.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginError"]="Kullanıcı adı ve parola uyuşmazlığı";
                }
            }
            else
            {
                TempData["LoginError"] = "Kullanıcı Bulunamadı";
            }

            return View("Index");
        }
    }
}
