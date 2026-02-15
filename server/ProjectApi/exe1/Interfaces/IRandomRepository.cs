using exe1.Dto;
using exe1.Models;

namespace exe1.Interfaces
{
    public interface IRandomRepository
    {
        Task<Prize> FindPrizeById(int prizeId);
        Task<User> FindUserById(int theUserId);
        Task<IEnumerable<Prize>> GetWinnerReport();
        Task SavetheChanges();
        Task<List<Purchase>> TheRandom(int prizeId);
    }
}