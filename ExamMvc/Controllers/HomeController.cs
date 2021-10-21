using ExamMvc.Models;
using ExamMvc.Models.ViewModels;
using ExamMvc.Services;
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
            var quizs = DataServices.Instance.QuizServices.GetAll();
            return View(quizs);
        }
        public IActionResult Delete(int Id)
        {
            var quiz = DataServices.Instance.QuizServices.Get(Id);
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                DataServices.Instance.AnswerServices.DeleteRange(quiz.Questions[i].Answers);
            }
            DataServices.Instance.QuestionServices.DeleteRange(quiz.Questions);
            DataServices.Instance.QuizServices.Delete(Id);
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
                return View("NewQuiz");
            }
            quizView.Quiz.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd mm:ss");
            var quizId = DataServices.Instance.QuizServices.AddOrUpdate(quizView.Quiz);
            

            for (int i = 0; i < quizView.Quiz.Questions.Count; i++)
            {
                quizView.Quiz.Questions[i].Quiz= DataServices.Instance.QuizServices.Get(quizId);
                var QuestionId = DataServices.Instance.QuestionServices.AddOrUpdate(quizView.Quiz.Questions[i]);
                for (int j = 0; j < quizView.Quiz.Questions[i].Answers.Count; j++)
                {
                    quizView.Quiz.Questions[i].Answers[j].Question= DataServices.Instance.QuestionServices.Get(QuestionId);
                    bool isRight = false;
                    if (quizView.Quiz.Questions[i].RightAnswerLetter == quizView.Quiz.Questions[i].Answers[j].AnswerLetter)
                        isRight = true;
                    quizView.Quiz.Questions[i].Answers[j].IsRight = isRight;
                    DataServices.Instance.AnswerServices.AddOrUpdate(quizView.Quiz.Questions[i].Answers[j]);
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult TakeQuiz(int Id)
        {
            var quiz = DataServices.Instance.QuizServices.Get(Id);
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
