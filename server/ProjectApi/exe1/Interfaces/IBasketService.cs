using exe1.Dto;
using exe1.Models;

namespace exe1.Interfaces
{
    public interface IBasketService
    {
        Task<string> DeletePrizeFromBasket(int prizeId, int userId);
        Task<IEnumerable<DtoListOrders>> GetPurchasesByPrize(int prizeId);
        Task<Prize> TheMostPurchasedPrizes();
        Task<Prize> theMostExpensivePrize();
        Task<Basket> GetBasketOfUser(int userId);
        Task<string> CompleteOrder(int userId);
        Task<string> AddPrizeToBasket(int prizeId, int userId);

    }
}