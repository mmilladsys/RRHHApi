using RRHHApi.DBModels;
using RRHHApi.Models;

namespace RRHHApi.Service
{
    public class UserService : IUserService
    {
        private readonly DBConnection _db = new DBConnection();
        public User Get (UserLogin userLogin)
        {
            User user = _db.T_USERS.AsEnumerable().
                Where(e => e.USER_NAME.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) 
                && e.PASSWORD.Equals(userLogin.Password)).
                Select(o => new User 
                {
                    Username = o.USER_NAME,
                    Email = o.USER_MAIL,
                    Password = o.PASSWORD,
                    Role = o.ROLE
                }).FirstOrDefault();
            return user;
        }
    }
}
