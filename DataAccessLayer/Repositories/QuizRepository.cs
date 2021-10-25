using DataAccessLayer.Concrete;
using DataAccessLayer.Interface;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class QuizRepository : IQuizDal
    {
        readonly Context db = new();
        public int AddOrUpdate(Quiz model)
        {
            int result = 0;

            {
                if (model.Id > 0)
                {
                    db.Quizs.Update(model);
                }
                else
                {
                    db.Quizs.Add(model);
                }

                db.SaveChanges();
                result = model.Id;
            }
            return result;
        }

        public void AddRange(IEnumerable<Quiz> models)
        {

            {
                db.Quizs.AddRange(models);
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var result = false;
            try
            {
                var model = db.Quizs.Include("Questions").Include("Questions.Answers").Where(e => e.Id == id).First();
                db.Quizs.Remove(model);
                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public void DeleteRange(params int[] quizIds)
        {
            foreach (var Id in quizIds)
            {
                Delete(Id);
            }
        }

        public void DeleteRange(IEnumerable<Quiz> quizs)
        {
            DeleteRange(quizs.Select(m => m.Id).ToArray());
        }

        public Quiz Get(int id)
        {
            Quiz res = null;

            {
                res = db.Quizs.AsNoTracking().Include("Questions").Include("Questions.Answers").Where(m => m.Id == id).FirstOrDefault();
            }
            return res;
        }

        public IEnumerable<Quiz> GetAll()
        {
            {
                return db.Quizs.Include("Questions").Include("Questions.Answers").AsNoTracking().AsEnumerable();
            }
        }
    }
}
