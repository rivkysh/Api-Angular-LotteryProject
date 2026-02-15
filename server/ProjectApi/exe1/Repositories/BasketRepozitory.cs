using exe1.data;
using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Security.Claims;

namespace exe1.Repositories
{
    internal class BasketRepozitory : IBasketRepository
    {
        private readonly ApiContext context;
       // private readonly IHttpContextAccessor _httpContextAccessor;
        public BasketRepozitory(ApiContext context)
        {
            this.context = context;
           // _httpContextAccessor = httpContextAccessor;
        }
        //GetPurchasesByPrize
        public async Task<IEnumerable<DtoListOrders>> GetPurchasesByPrize(int prizeId)
        {
            var purchases = await context.Tickets
                .Where(t => t.prize.Id == prizeId&& t.prize.IsActive == true)
                .Select(t => new DtoListOrders
                {
                    prize = t.prize,
                    user = t.user,
                    ticketsAmaunt = 1,
                    date = t.OrderDate
                }).ToListAsync();
            return purchases;
        }
        //TheMostPurchasedPrizes
        public async Task<IEnumerable<Prize>> TheMostPurchasedPrizes()
        {
            var result = await context.Prizes.ToListAsync();
            return result;
        }
        //
        public async Task<User> FindUserById(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            return user;
        }
        //
        public async Task<Prize> FindPrizeById(int prizeId)
        {
            var prize = await context.Prizes.FirstOrDefaultAsync(x => x.Id == prizeId);
            return prize;
        }
        public async Task<string> AddPrizeToBasket( int prizeId ,int userId)
        {
            var basket = await context.Baskets
                .Include(b => b.YourTickets)
                .FirstOrDefaultAsync(x=>x.UserId == userId);
            if (basket == null)
            {
                basket = new Basket { UserId = userId, YourTickets = new List<Ticket>() };
                context.Baskets.Add(basket);
            }
            Prize? p = await context.Prizes.FirstOrDefaultAsync(x => x.Id == prizeId);
            Ticket ticket = new Ticket()
            {
                prize =p,
                UserId = userId,
                OrderDate = DateTime.Now
            };

            basket.YourTickets.Add(ticket);
            await context.SaveChangesAsync();
            return "הכרטיס נוסף לסל בהצלחה";
        }
        //GetBasketOfUser
        public async Task<Basket> GetBasketOfUser(int userId)
        {
            var basket = await context.Baskets
                .Include(b => b.YourTickets.Where(t => t.prize.Islottered == false))
                .ThenInclude(t => t.prize)
                .FirstOrDefaultAsync(b => b.UserId == userId);
            if (basket == null)
            {
                basket = new Basket { UserId = userId, YourTickets = new List<Ticket>() };
                context.Baskets.Add(basket);
                await context.SaveChangesAsync();
            }
            return basket;
        }
        //CompleteOrderStage2
        public async Task<IEnumerable<Ticket>> CompleteOrderStage2(int userId)
        {
            var basket = await context.Baskets
               .Include(b => b.YourTickets)
                .ThenInclude(t => t.prize)
                .FirstOrDefaultAsync(b => b.UserId == userId);
            return basket.YourTickets;
        }

        public async Task SavetheChanges()
        {
            await context.SaveChangesAsync();
            return;
        }

        public async Task AddPurchase(Purchase purchase)
        {
            await context.Purchases.AddAsync(purchase);
        }
    }
}
