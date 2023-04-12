using NetCoreAPIBasicAuthenticationSample.Models;

namespace NetCoreAPIBasicAuthenticationSample.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel Login(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<UserModel> _users;
        public UserService()
        {
            _users = new List<UserModel>() 
            { 
                new UserModel{ Username = "user1", EmailAddress="user1@user1.com", Password="1234" },
                new UserModel{ Username = "user2", EmailAddress="user2@user2.com", Password="1234" }
            };
        }

        public List<UserModel> GetUsers()
        {
            return _users;
        }

        public UserModel Login(string username, string password)
        {
            var user = _users.FirstOrDefault(x=> x.Username == username && x.Password == password);

            return user;
        }
    }
}
