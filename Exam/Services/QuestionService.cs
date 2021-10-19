using Exam.Data;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public class QuestionService : IServiceInterface<Question>
    {
        public int AddOrUpdate(Question model)
        {
            int result = 0;
            using(var db= new ExamDbContext())
            {
                if(model.Id > 0)
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
            using (var db = new ExamDbContext())
            {
                db.Questions.AddRange(models);
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

        public Question Get(int id)
        {
            Question res = null;
            using (var db = new ExamDbContext())
            {
               res=db.Questions.Find(id);
            }
            return res;
        }

        public IEnumerable<Question> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Questions.ToList();
            }
        }
    }
}
