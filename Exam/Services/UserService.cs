using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public class UserService:IServiceInterface<User>
    {
        public static User GetUserByUsername(string Username)
        {
            User result = null;
            using(Data.ExamDbContext context=new Data.ExamDbContext())
            {
                result = context.Users.Where(u => u.Username == Username).FirstOrDefault();
            }
            return result;
        }

        public int AddOrUpdate(User model)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<User> models)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
