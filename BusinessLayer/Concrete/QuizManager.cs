using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;
        IQuestionDal _questionDal;
        IAnswerDal _answerDal;
        public QuizManager()
        {
            if(_quizDal==null)
            {
                _quizDal = new QuizRepository();
                _questionDal = new QuestionRepository();
                _answerDal = new AnswerRepository();
            }
        }
        public int AddOrUpdate(Quiz model)
        {

            for (int i = 0; i < model.Questions.Count; i++)
            {
                for (int j = 0; j < model.Questions[i].Answers.Count; j++)
                {
                    bool isRight = false;
                    if (model.Questions[i].RightAnswerLetter == model.Questions[i].Answers[j].AnswerLetter)
                        isRight = true;
                    model.Questions[i].Answers[j].IsRight = isRight;
                }
            }

            model.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd mm:ss");
            return _quizDal.AddOrUpdate(model);
        }

        public void AddRange(IEnumerable<Quiz> models)
        {
            _quizDal.AddRange(models);
        }

        public bool Delete(int id)
        {
            return _quizDal.Delete(id);
        }
        public bool Delete(int id,bool withInner)
        {
            if(!withInner)
            {
                Delete(id);
            }
            var q = _quizDal.Get(id);
            for (int i = 0; i < q.Questions.Count; i++)
            {
                _answerDal.DeleteRange(q.Questions[i].Answers);
            }
            _questionDal.DeleteRange(q.Questions);
            return _quizDal.Delete(id);
        }

        public void DeleteRange(params int[] modelIds)
        {
            _quizDal.DeleteRange(modelIds);
        }

        public void DeleteRange(IEnumerable<Quiz> models)
        {
            _quizDal.DeleteRange(models);
        }

        public Quiz Get(int id)
        {
            return _quizDal.Get(id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _quizDal.GetAll();
        }
    }
}
