using exe1.data;
using exe1.Interfaces;
using exe1.Models;
using Microsoft.EntityFrameworkCore;

namespace exe1.Repositories
{
    internal class UserRepository: IUserRepository
    {
        private readonly ApiContext context;

        public UserRepository(ApiContext context)
        {
            this.context = context;
        }
        public async Task<User> CreatUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetByUserName(string userName)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}