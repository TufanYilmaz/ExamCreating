using DataAccessLayer.Concrete;
using DataAccessLayer.Interface;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class QuestionRepository : IQuestionDal
    {
        Context db = new Context();
        public int AddOrUpdate(Question model)
        {
            int result = 0;
             
            {
                if (model.Id > 0)
                {
                    db.Questions.Update(model);
                }
                else
                {
                    db.Questions.Add(model);
                }

                db.SaveChanges();
                result = model.Id;
            }
            return result;
        }

        public void AddRange(IEnumerable<Question> models)
        {
             
            {
                db.Questions.AddRange(models);
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var result = false;
             
            {
                try
                {
                    var model = db.Questions.Find(id);
                    db.Questions.Remove(model);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
            }
            return result;
        }
        public void DeleteRange(List<Question> questions)
        {
            DeleteRange(questions.Select(m => m.Id).ToArray());
        }
        public void DeleteRange(params int[] questionIds)
        {
            foreach (var Id in questionIds)
            {
                Delete(Id);
            }
        }

        public void DeleteRange(IEnumerable<Question> questions)
        {
            DeleteRange(questions.Select(m => m.Id).ToArray());
        }

        public Question Get(int id)
        {
            Question res = null;
             
            {
                res = db.Questions.AsNoTracking().Where(m => m.Id == id).FirstOrDefault();
            }
            return res;
        }

        public IEnumerable<Question> GetAll()
        {
             
            {
                return db.Questions.AsNoTracking().AsEnumerable();
            }
        }
    }
}
