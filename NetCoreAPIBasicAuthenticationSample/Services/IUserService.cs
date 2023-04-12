using NetCoreAPIBasicAuthenticationSample.Models;

namespace NetCoreAPIBasicAuthenticationSample.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel Login(string username, string password);
    }
}
