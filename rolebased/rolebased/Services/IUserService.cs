using rolebased.Models;

namespace rolebased.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
