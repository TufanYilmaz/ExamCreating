using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = Services.Services.Instance.QuizServices.GetAll();
            return View(model);
        }
        public IActionResult Delete(int Id)
        {
            return View();
        }
        public IActionResult NewQuiz()
        {
            return View();
        }
        public IActionResult ShowQuiz(int Id)
        {
            return View();
        }
    }
}
