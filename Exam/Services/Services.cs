using Exam.Data;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public class Services
    {
        public static Services Instance { get; } = new Services();
        Services()// private constructor ile sadece tek Instance kullanımı garanti ediliyor.
        {

        }
        QuizService quizServices;
        public QuizService QuizServices { get
            {
                if (quizServices == null)
                    quizServices = new QuizService();
                return quizServices;
            }
        }
        QuestionService questionServices;
        public QuestionService QuestionServices
        {
            get
            {
                if (questionServices == null)
                    questionServices = new QuestionService();
                return questionServices;
            }
        }
        AnswerService answerServices;
        public AnswerService AnswerServices
        {
            get
            {
                if (answerServices == null)
                    answerServices = new AnswerService();
                return answerServices;
            }
        }
        UserService userServices;
        public UserService UserServices
        {
            get
            {
                if (userServices == null)
                    userServices = new UserService();
                return userServices;
            }
        }
    }
}
