using exe1.data;
using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;

namespace exe1.Services
{
    internal class BasketService:IBasketService
    {
        private readonly IBasketRepository repository;

        public BasketService(IBasketRepository repository)
        {
            this.repository = repository;
        }
        //GetPurchasesByPrize
        public async Task<IEnumerable<DtoListOrders>> GetPurchasesByPrize(int prizeId)
        {
            return await repository.GetPurchasesByPrize(prizeId);
        }
        //TheMostPurchasedPrizes
        public async Task<Prize> TheMostPurchasedPrizes()
        {
            var prizes= await repository.TheMostPurchasedPrizes();
            var TheMostPurchasedPrizes = new Prize();
            foreach (var item in prizes)
            {
                if(item.PurchacesAmount> TheMostPurchasedPrizes.PurchacesAmount)
                    {
                    TheMostPurchasedPrizes = item;
                    }
            }
            return TheMostPurchasedPrizes;
        }
        //theMostExpensivePrize
        public async Task<Prize> theMostExpensivePrize()
        {
            var prizes = await repository.TheMostPurchasedPrizes();
            var theMostExpensivePrize = new Prize();
            foreach (var item in prizes)
            {
                if (item.Price > theMostExpensivePrize.Price)
                {
                    theMostExpensivePrize = item;
                }
            }
            return theMostExpensivePrize;
        }
        
        public async Task<string> AddPrizeToBasket(int prizeId, int userId)
        {
            return await repository.AddPrizeToBasket(prizeId, userId);
        }

        //GetBasketOfUser
        public async Task<Basket> GetBasketOfUser(int userId)
        {
          return await repository.GetBasketOfUser( userId);
        }
        //CompleteOrder
        public async Task<string> CompleteOrder(int userId)
        {
            var basket = await repository.GetBasketOfUser(userId);
            if (basket == null || basket.YourTickets.Count == 0)
            {
                return "הסל ריק, אין מה להשלים";
            }
           var userTicket=await repository.CompleteOrderStage2(userId);
            foreach (var ticket in userTicket)
            {
                ticket.prize.PurchacesAmount += 1;
                Purchase purchase = new Purchase()
                {
                    PrizeId = ticket.prize.Id,
                    UserId = ticket.UserId,
                };
                await repository.AddPurchase(purchase);

            }

            basket.YourTickets.Clear();
            await repository.SavetheChanges();
             return "ההזמנה הושלמה בהצלחה";

        }
        //DeletePrizeFromBasket
        public async Task<string> DeletePrizeFromBasket(int prizeId, int userId)
        {
            var basket = await repository.GetBasketOfUser(userId);
            if (basket == null)
            {
                return "הסל ריק, אין מה למחוק";
            }
            var ticketToRemove = basket.YourTickets.FirstOrDefault(t => t.prize.Id == prizeId);
            if (ticketToRemove != null)
            {
                basket.YourTickets.Remove(ticketToRemove);
                await repository.SavetheChanges();
                return "הפרס הוסר מהסל בהצלחה";
            }
            return "הפרס לא נמצא בסל";
            
        }
    }
}
