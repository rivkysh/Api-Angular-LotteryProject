using exe1.Models;

namespace exe1.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreatUser(User user);
        Task<User?> GetByUserName(string userName);
    }
}