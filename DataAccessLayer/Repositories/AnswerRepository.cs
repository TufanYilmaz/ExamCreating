using DataAccessLayer.Concrete;
using DataAccessLayer.Interface;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class AnswerRepository : IAnswerDal
    {
        Context db = new Context();

        public int AddOrUpdate(Answer model)
        {
            int result = 0;
             
            {
                if (model.Id > 0)
                {
                    db.Answers.Update(model);
                }
                else
                {
                    db.Answers.Add(model);
                }
                db.SaveChanges();
                result = model.Id;
            }
            return result;
        }

        public void AddRange(IEnumerable<Answer> models)
        {
             
            {
                db.Answers.AddRange(models);
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var result = false;
             
            {
                try
                {
                    var model = db.Answers.Find(id);
                    db.Answers.Remove(model);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
            }
            return result;
        }
        //public void DeleteRange(List<Answer> answers)
        //{
        //    DeleteRange(answers.Select(m => m.Id).ToArray());
        //}
        public void DeleteRange(params int[] answerIds)
        {
            foreach (var Id in answerIds)
            {
                Delete(Id);
            }
        }

        public void DeleteRange(IEnumerable<Answer> answers)
        {
            DeleteRange(answers.Select(m => m.Id).ToArray());
        }

        public Answer Get(int id)
        {
            Answer res = null;
             
            {
                res = db.Answers.Find(id);
            }
            return res;
        }

        public IEnumerable<Answer> GetAll()
        {
             
            {
                return db.Answers.AsNoTracking().AsEnumerable();
            }
        }
    }
}
