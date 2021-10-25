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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager()
        {
            _questionDal = new QuestionRepository();
        }

        public int AddOrUpdate(Question model)
        {
            return _questionDal.AddOrUpdate(model);
        }

        public void AddRange(IEnumerable<Question> models)
        {
            _questionDal.AddRange(models);
        }

        public bool Delete(int id)
        {
            return _questionDal.Delete(id);
        }

        public void DeleteRange(params int[] modelIds)
        {
            _questionDal.DeleteRange(modelIds);
        }

        public void DeleteRange(IEnumerable<Question> models)
        {
            _questionDal.DeleteRange(models);
        }

        public Question Get(int id)
        {
            return _questionDal.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionDal.GetAll();
        }
    }
}
