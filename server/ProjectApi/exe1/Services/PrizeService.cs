using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exe1.Services
{
    public class PrizeService: IPrizeService
    {
        private readonly IPrizeRepository repository;

        public PrizeService(IPrizeRepository repository)
        {
            this.repository = repository;
        }
        //GetPrize
        public async Task<IEnumerable<Prize>> GetPrize()
        {
            var prizes=  await repository.GetPrize();
            return prizes;

        }
        //GetPrizeById
        public async Task<Prize> GetPrizeById(int id)
        {
            var p = await repository.GetPrizeById(id);
            if (p == null)
                return null;
            return p;
        }
        //AddNewPrize
        public async Task<Prize> AddNewPrize(DtoInsertPrize dto)
        {
            var prize = new Prize();
            prize.Name = dto.Name;
            prize.DonorId = dto.DonorId;
            prize.Price = dto.Price;
            prize.CategoryId = dto.CategoryId;
            prize.Description = dto.Description;
            prize.ImgUrl = dto.ImgUrl;
            await repository.AddNewPrize(prize);
            return prize;


        }
        //RemovePrize
        public async Task<bool> RemovePrize(int id)
        {
            return await repository.RemovePrize(id);
        }
        //UpdatePrize
        public async Task<Prize?> UpdatePrize(int id, PrizeUpdateDto dto)
        {
            var p = await repository.GetPrizeById(id);
            if (p == null) return null;

            p.Name = dto.Name;
            p.Description = dto.Description;
            p.DonorId = dto.DonorId;
            p.CategoryId = dto.CategoryId;
            p.Price = dto.Price;
            p.ImgUrl = dto.ImgUrl;
            await repository.SaveUpdate(p);
            return p;
        }
        //GetDonorByPrizeId
        public async Task<DtoDonerDatalies>? GetDonorByPrizeId(int prizeId)
        {
            var donor = await repository.GetDonorByPrizeId(prizeId);
            DtoDonerDatalies dtoDonerDatalies= new DtoDonerDatalies();
            dtoDonerDatalies.Name = donor.Name;
            dtoDonerDatalies.Email = donor.Email;
            dtoDonerDatalies.PhoneNumber = donor.PhoneNumber;
            return dtoDonerDatalies;
        }
        public async Task<ActionResult<IEnumerable<Prize>>>GetListPrizesByCategory(string category)
        {
            var prizes = await repository.GetListPrizesByCategory(category);
            return prizes;
        }
    }

}