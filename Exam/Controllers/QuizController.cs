using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
