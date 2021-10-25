using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ExamMvc.Models.ViewModels
{

    public class QuizViewModel
    {
        public List<QuizReferance> QuizReferances { get; set; } = new List<QuizReferance>();
        public Quiz Quiz { get; set; } = new Quiz();
        public string QuizContent { get; set; }

        public QuizViewModel()
        {
        }
        public QuizViewModel(Dictionary<string,string> quizReferances,int questionCount,int answerCount)
        {
            QuizReferances = quizReferances.Select(n => new QuizReferance() { Title = n.Key, Url = n.Value }).ToList();
            for (int i = 0; i < questionCount; i++)
            {
                var temp = new Question(answerCount);
                Quiz.Questions.Add(temp);
            }
        }
    }
}
