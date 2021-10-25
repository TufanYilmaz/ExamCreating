using EntityLayer.Concrete;

namespace DataAccessLayer.Interface
{
    public interface IUserDal : IBaseDal<User>
    {
        User GetUserByUsername(string Username);
    }
}
