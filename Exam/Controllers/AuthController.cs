﻿using Exam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user, string ReturnUrl)
        {
            var tUser = Services.Services.Instance.UserServices.GetUserByUsername(user.Username);
            if (tUser != null)
            {
                if (tUser.Password == user.Password.ToString())
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
                    var claimIdentity = new ClaimsIdentity(claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginError = "Kullanıcı adı ve parola uyuşmazlığı";
                }
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı Bulunamadı";
            }
            
            return View("Index");
        }

    }
}
