using BusinessLayer.Interface;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;

        public AnswerManager()
        {
            _answerDal = new AnswerRepository();
        }

        public int AddOrUpdate(Answer model)
        {
            return _answerDal.AddOrUpdate(model);
        }

        public void AddRange(IEnumerable<Answer> models)
        {
            _answerDal.AddRange(models);
        }

        public bool Delete(int id)
        {
            return _answerDal.Delete(id);
        }

        public void DeleteRange(params int[] modelIds)
        {
            _answerDal.DeleteRange(modelIds);
        }

        public void DeleteRange(IEnumerable<Answer> models)
        {
            _answerDal.DeleteRange(models);
        }

        public Answer Get(int id)
        {
            return _answerDal.Get(id);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _answerDal.GetAll();
        }
    }
}
