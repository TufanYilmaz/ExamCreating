using ExamMvc.Data;
using ExamMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMvc.Services
{
    public class AnswerService : IServiceInterface<Answer>
    {
        public int AddOrUpdate(Answer model)
        {
            int result = 0;
            using (var db = new ExamDbContext())
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
            using (var db = new ExamDbContext())
            {
                db.Answers.AddRange(models);
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
        public void DeleteRange(List<Answer> answers)
        {
            DeleteRange(answers.Select(m => m.Id).ToArray());
        }
        public void DeleteRange(params int[] answerIds)
        {
            foreach (var Id in answerIds)
            {
                Delete(Id);
            }
        }
        public Answer Get(int id)
        {
            Answer res = null;
            using (var db = new ExamDbContext())
            {
                res = db.Answers.Find(id);
            }
            return res;
        }

        public IEnumerable<Answer> GetAll()
        {
            using (var db = new ExamDbContext())
            {
                return db.Answers.ToList();
            }
        }
    }
}
