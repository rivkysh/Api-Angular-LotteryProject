using exe1.data;
using exe1.data;
using exe1.Dto;
using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace exe1.Repositories
{
    public class PrizeRepository:IPrizeRepository
    {
        //  BookContext context= ProductContextFactory.CreateContext();
        private readonly ApiContext context;
        public PrizeRepository(ApiContext context)
        {
            this.context = context;
        }
        //GetPrize
        public async Task<IEnumerable<Prize>> GetPrize()
        {
            var prizes = await context.Prizes.
                Include(x=>x.Thewinner).
                Where(x=>x.IsActive==true).
                ToListAsync();

            return prizes;
        }

        //GetPrizeById
        public async Task<Prize> GetPrizeById(int id)
        {
            var p = await context.Prizes.FirstOrDefaultAsync(x => x.Id == id);
            return p;
        }
        //AddNewPrize
        public async Task AddNewPrize(Prize prize)
        {
            await context.Prizes.AddAsync(prize);
            await context.SaveChangesAsync();

        }
        //RemovePrize
        public async Task<bool> RemovePrize(int id)
        {
            var prize = await context.Prizes.FindAsync(id);
            if (prize == null)
                return false;

            prize.IsActive = false;   // 👈 הסתרה
            await context.SaveChangesAsync();

            return true;
        }
        //SaveUpdate
        public async Task SaveUpdate(Prize prize)
        {
            await context.SaveChangesAsync();
        }
        //GetDonorByPrizeId
        public async Task<Donor>? GetDonorByPrizeId(int prizeId)
        {
          var prize = await context.Prizes
         .Include(p => p.Donor)
         .FirstOrDefaultAsync(p => p.Id == prizeId);
         
            
            return prize?.Donor;
        }
        public async Task<ActionResult<IEnumerable<Prize>>> GetListPrizesByCategory(string category)
        {
            var prizes = context.Prizes.
                Where(x => x.Category.Name == category&&x.IsActive==true).ToListAsync();
            return  await prizes;
        }


    }

}
