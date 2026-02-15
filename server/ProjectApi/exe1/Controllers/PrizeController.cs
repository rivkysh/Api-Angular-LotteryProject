using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Services;
using Microsoft.AspNetCore.Mvc;

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PrizeController : ControllerBase
    {
        private readonly IPrizeService service;
        public PrizeController(IPrizeService service)
        {
            this.service = service;
        }

        [HttpGet("GetListPrizes")]
        public async Task<ActionResult<IEnumerable<Prize>>> Get()
        {
            var prizes = await service.GetPrize();
            return Ok(prizes);
        }
        [HttpGet("GetListPrizesByCategory/{category}")]
        public async Task<ActionResult<IEnumerable<Prize>>> GetListPrizesByCategory(string category)
        {
            var prizes = await service.GetListPrizesByCategory(category);

            return Ok(prizes);
        }

        [HttpGet]
        [Route("GetPrizeById/{id}")]
        public async Task<Prize> GetPrizeById(int id)
        {
            return await service.GetPrizeById(id);
        }


        [HttpPost]
        [Route("AddNewPrize")]
        public async Task<Prize> AddNewPrize(DtoInsertPrize dto)
        {
            return await service.AddNewPrize(dto);
        }

        [HttpDelete]
        [Route("RemovePrize/{id}")]
        public async Task<bool> RemovePrize(int id)
        {
            return await service.RemovePrize(id);
        }
        [HttpPut]
        [Route("UpdatePrize/{id}")]
        public async Task<Prize> UpdatePrize(int id, [FromBody] PrizeUpdateDto dto)
        {
            return await service.UpdatePrize(id,dto);
        }
        [HttpGet]
        [Route("GetDonorByPrizeId/{id}")]
        public async Task<DtoDonerDatalies> GetDonorByPrizeId(int id)
        {
            return await service.GetDonorByPrizeId(id);
        }
        
    }
}