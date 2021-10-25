using DataAccessLayer.Concrete;
using DataAccessLayer.Interface;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserDal
    {
        public User GetUserByUsername(string Username)
        {
            User result = null;
            using (Context context = new Context())
            {
                result = context.Users.Where(u => u.Username == Username)?.FirstOrDefault();
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

        public void DeleteRange(params int[] modelIds)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<User> models)
        {
            throw new NotImplementedException();
        }
    }
}
