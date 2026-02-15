using exe1.data;
using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
namespace exe1.Repositories
{
    public class DonerRepository: IDonorRepository
    {
        private readonly ApiContext context;
        public DonerRepository(ApiContext context)
        {
            this.context = context;
        }

        //GetDoners
        public async Task<IEnumerable<Donor>> GetDoners()
        {
            var doners = await context.Donors.
                Where(d=>d.IsActive==true).
                ToListAsync();
            return doners;
        }
        //GetDonersWithPrizes
        public async Task<IEnumerable<Donor>> GetDonersWithPrizes()
        {
            var doners = await context.Donors.
                Where(d => d.IsActive == true).
                Include(d=>d.prizes).
                ToListAsync();
            return doners;
        }
        //AddNewDonor
        public async Task<Donor> AddNewDonor(Donor donor)
        {
            await context.Donors.AddAsync(donor);
            await context.SaveChangesAsync();
            return donor;
        }
        //GetDonorById
        public async Task<Donor>? GetDonorById(int id)
        {
           var x=await context.Donors.FirstOrDefaultAsync(x => x.Id == id);
            if (x == null)
                return null;
            return x;
        }
        //SaveDonor
        public async Task SaveDonor(Donor donor)
        {
            await context.SaveChangesAsync();
        }
        //RemoveDonor
        public async Task<bool> RemoveDonor(int id)
        {
            var donor = await context.Donors
                .Include(d => d.prizes)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (donor == null) return false;

            foreach (var prize in donor.prizes)
            {
                prize.IsActive = false;
            }

            donor.IsActive = false;

            await context.SaveChangesAsync();
            return true;
        }
       
        //GetPrizesByDonor
        public async Task<IEnumerable<Prize>> GetPrizesByDonor(int id)
        {
          return await context.Prizes
         .Where(p => p.DonorId == id&&p.IsActive==true)
         .ToListAsync();
        }
        
    }
}