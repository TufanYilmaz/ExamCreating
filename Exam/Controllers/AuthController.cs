using Exam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [AllowAnonymous]
    //[Route("auth")]
    public class AuthController : Controller
    {
        //[Route("")]
        //[Route("~/")]
        //[Route("/index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user,string ReturnUrl)
        {
            if(user.Username=="tufan" && user.Password=="password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Username),
                };
                var claimIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity));
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı adı ve parola uyuşmazlığı";
            }
            return View();
        }

    }
}
