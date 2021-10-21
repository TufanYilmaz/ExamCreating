using ExamMvc.Models;
using ExamMvc.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var users = Services.Services.Instance.UserServices.GetUserByUsername("twofun");
            return View();
        }
        public IActionResult Delete(int Id)
        {
            return View();
        }
        public IActionResult NewQuiz()
        {
            var quizrefer = WebCrowlerHelper.WebCrowlerClient.instance.GetWiredLastFiveMostRecent();
            var model = new QuizViewModel(quizrefer,4,4);
            return View(model);
        }
        [HttpPost]
        public IActionResult AddQuiz(QuizViewModel quizView)
        {

            return View("Index");
        }
        public IActionResult ShowQuiz(int Id)
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        public IActionResult GetReferancedQuizContent(string URL)
        {
            var content = WebCrowlerHelper.WebCrowlerClient.instance.GetWiredStroyContentFromUrl(URL);
            return Content(content);
        }
    }
}
