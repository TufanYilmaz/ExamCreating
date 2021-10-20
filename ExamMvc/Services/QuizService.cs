using ExamMvc.Data;
using ExamMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamMvc.Services
{
    public class QuizService : IServiceInterface<Quiz>
    {
        public int AddOrUpdate(Quiz model)
        {
            int result = 0;
            using (var db = new ExamDbContext())
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
            using (var db = new ExamDbContext())
            {
                db.Quizs.AddRange(models);
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var result = false;
            using (var db = new ExamDbContext())
            {
                try
                {
                    var model = db.Quizs.Find(id);
                    db.Quizs.Remove(model);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                }
            }
            return result;
        }

        public Quiz Get(int id)
        {
            Quiz res = null;
            using (var db = new ExamDbContext())
            {
                res = db.Quizs.Find(id);
            }
            return res;
        }

        public IEnumerable<Quiz> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Quizs.ToList();
            }
        }
    }
}
