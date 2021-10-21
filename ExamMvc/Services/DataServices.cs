using ExamMvc.Data;
using ExamMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMvc.Services
{
    public class DataServices
    {
        public static DataServices Instance { get; } = new DataServices();
        DataServices()// private constructor ile sadece tek Instance kullanımı garanti ediliyor.
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
