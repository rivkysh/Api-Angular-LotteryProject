using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonerController : ControllerBase
    {
        private readonly IDonorService service;

        public DonerController(IDonorService service)
        {
            this.service = service;
        }
        //GetDoners
        [HttpGet("GetListDoners")]
        public async Task<IEnumerable<Donor>> Get()
        {
            var doners = await service.GetDoners();
            return doners;
        }
        //AddNewDonor
        [HttpPost("AddNewDonor")]
        public async Task<Donor> AddNewDonor(DtoAddDonor dto)
        {
            return await service.AddNewDonor(dto);
        }
        //UpdateDonor
        [HttpPut("UpdateDonor/{id}")]
        public async Task<Donor> UpdateDonor(DtoUpdateDonor dto, int id)
        {
            return await service.UpdateDonor(dto, id);
        }
        //RemoveDonor   
        [HttpDelete("RemoveDonor/{id}")]
        public async Task<bool> RemoveDonor(int id)
        {
            return await service.RemoveDonor(id);
        }
        //GetPrizesByDonor
        [HttpGet("GetPrizesByDonor/{id}")]
        public async Task<IEnumerable<Prize>> GetPrizesByDonor([FromRoute] int id)
        {
            return await service.GetPrizesByDonor(id);
        }
        //GetDonorByName
        [HttpGet("GetDonorByName/{name}")]
        public async Task<IEnumerable<Donor>> GetDonorByName(string name)
        {
            return await service.GetDonorByName(name);
        }
        //GetDonorByName
        [HttpGet("GetDonorByEmail/{email}")]
        public async Task<IEnumerable<Donor>> GetDonorByEmail(string email)
        {
            return await service.GetDonorByEmail(email);
        }
        //GetDonorByPrize
        [HttpGet("GetDonorByPrize/{prize}")]
        public async Task<IEnumerable<Donor>> GetDonorByPrize(string prize)
        {
            return await service.GetDonorByPrize(prize);
        }
    }
}