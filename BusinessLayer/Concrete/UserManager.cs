using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager()
        {
            if (_userDal == null)
            {
                _userDal = new UserRepository();
            }
        }
        public int AddOrUpdate(User model)
        {
            return _userDal.AddOrUpdate(model);
        }

        public void AddRange(IEnumerable<User> models)
        {
            _userDal.AddRange(models);
        }

        public bool Delete(int id)
        {
            return _userDal.Delete(id);
        }

        public void DeleteRange(params int[] modelIds)
        {
            _userDal.DeleteRange(modelIds);
        }

        public void DeleteRange(IEnumerable<User> models)
        {
            _userDal.DeleteRange(models);
        }

        public User Get(int id)
        {
            return _userDal.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDal.GetAll();
        }
        public User GetUserByName(string username)
        {
            return _userDal.GetUserByUsername(username);
        }
    }
}
