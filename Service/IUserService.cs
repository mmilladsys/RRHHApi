using RRHHApi.Models;

namespace RRHHApi.Service
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
