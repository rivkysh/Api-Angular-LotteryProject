using exe1.Dto;
using exe1.Models;
using exe1.Services;

namespace exe1.Interfaces
{
    public interface IBasketRepository
    {
        Task<User> FindUserById(int userId);
        Task<IEnumerable<DtoListOrders>> GetPurchasesByPrize(int prizeId);
        Task<IEnumerable<Prize>> TheMostPurchasedPrizes();
        Task<Prize> FindPrizeById(int prizeId);
        Task<string> AddPrizeToBasket(int prizeId, int userId);
        Task<Basket> GetBasketOfUser(int userId);
        Task<IEnumerable<Ticket>> CompleteOrderStage2(int userId);
        Task SavetheChanges();
        Task AddPurchase(Purchase purchase);
    }

}