using BusinessLayer.Concrete;
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
        QuizManager quizManager = new QuizManager();
        AnswerManager answerManager = new AnswerManager();
        QuestionManager questionManager = new QuestionManager();
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
            var quizs = quizManager.GetAll();
            return View(quizs);
        }
        public IActionResult Delete(int Id)
        {
            quizManager.Delete(Id, true);
            return RedirectToAction("Index");
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
            if(!ModelState.IsValid)
            {
                return RedirectToAction("NewQuiz");
            }
            quizManager.AddOrUpdate(quizView.Quiz);
            return RedirectToAction("Index");
        }
        public IActionResult TakeQuiz(int Id)
        {
            var quiz = quizManager.Get(Id);
            var content = WebCrowlerHelper.WebCrowlerClient.instance.GetWiredStroyContentFromUrl(quiz.RefUrl);
            QuizViewModel model = new QuizViewModel();
            model.QuizContent = content;
            model.Quiz = quiz;

            return View(model);
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
        public IActionResult EvaluateQuiz(QuizViewModel model)
        {
            var viewmModel = new List<QuestionEvaluate>();
            int i = 0;
            foreach (var question in model.Quiz.Questions)
            {
                var temp = new QuestionEvaluate
                {
                    QuestionId = question.Id,
                    QuestionNumber = i++,
                    SelectedAnswer = question.SelectedAnswerLetter,
                    Right = question.SelectedAnswerLetter == question.Answers.Where(a => a.IsRight).First().AnswerLetter
                };
                viewmModel.Add(temp);
            }
            return Json(viewmModel);
        }
    }
}
