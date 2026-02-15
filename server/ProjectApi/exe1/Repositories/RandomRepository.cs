using exe1.data;
using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using Microsoft.EntityFrameworkCore;

namespace exe1.Repositories
{
    internal class RandomRepository: IRandomRepository
    {
        private readonly ApiContext context;
        public RandomRepository(ApiContext context)
        {
            this.context = context;
        }
        //TheRandom
        public async Task<List<Purchase>> TheRandom(int prizeId)
        {
            var purchas = await context.Purchases
                .Where(b => b.PrizeId==prizeId)
               .ToListAsync();
            return purchas;       
        }
        public async Task<User> FindUserById(int theUserId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == theUserId);
            return user;
        }

        public async Task<Prize> FindPrizeById(int prizeId)
        {
            return  await context.Prizes.FirstOrDefaultAsync(x => x.Id == prizeId);
        }


        public async Task<IEnumerable<Prize>> GetWinnerReport()
        {
            return await context.Prizes
                .Include(p => p.Thewinner)
        .ToListAsync();
        }

        public async Task SavetheChanges()
        {
             await context.SaveChangesAsync();
        }

        public async Task AddPurchase(Purchase purchase)
        {
            await context.Purchases.AddAsync(purchase);
        }
    }
}