using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using System.Collections.Generic;
using System.ComponentModel;
namespace exe1.Services
{
    public class DonerService: IDonorService
    {
        private readonly IDonorRepository repository;
        private readonly ILogger<DonerService> logger;

        public DonerService(IDonorRepository repository, ILogger<DonerService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        //GetDoners
        public async Task<IEnumerable<Donor>> GetDoners()
        {
            var doners = await repository.GetDoners();
            return doners;
        }
        //AddNewDonor
        public async Task<Donor> AddNewDonor(DtoAddDonor dto)
        {
            Donor donor = new Donor
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber= dto.PhoneNumber
            };
            return await repository.AddNewDonor(donor);
        }
        //UpdateDonor
        public async Task<Donor> UpdateDonor(DtoUpdateDonor dto,int id)
        {
            var d = await repository.GetDonorById(id);
            if (d == null)
                return null;
            d.Name = dto.Name;
            d.PhoneNumber = dto.PhoneNumber;
            d.Email = dto.Email;
            await repository.SaveDonor(d);
            return d;
        }
        //RemoveDonor
        public async Task<bool> RemoveDonor(int id)
        {
            return await repository.RemoveDonor(id);
        }
        //GetPrizesByDonor
        public async Task<IEnumerable<Prize>> GetPrizesByDonor(int id)
        {
            return await repository.GetPrizesByDonor(id);
        }
        // GetDonorByName
        public async Task<IEnumerable<Donor>> GetDonorByName(string name)
        {
            logger.LogInformation("מנסה לשלוף תורם עם שם: {name}", name);

            var allDonors = await repository.GetDoners();

            var donorsByName = allDonors.Where(d => d.Name.Contains(name)).ToList();

            return donorsByName;
        }
        //GetDonorByEmail
        public async Task<IEnumerable<Donor>> GetDonorByEmail(string email)
        {
            var allDonors = await repository.GetDoners();
            var donorsByEmail = allDonors.Where(d => d.Email.Contains(email)).ToList();
            return donorsByEmail;
        }


        //GetDonorByPrize
        public async Task<IEnumerable<Donor>> GetDonorByPrize(string prize)
        {
            
            var allDonors = await repository.GetDonersWithPrizes();
            allDonors = allDonors;
               var donorsByPrize = allDonors.Where(d => d.prizes.Any(x=>x.Name.Contains(prize))).ToList();
            return donorsByPrize;
        }
    }
}
