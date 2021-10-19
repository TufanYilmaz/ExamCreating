using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public class UserService
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
    }
}
