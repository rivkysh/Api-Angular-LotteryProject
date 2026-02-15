using exe1.Interfaces;
using exe1.Models;
using Microsoft.AspNetCore.Mvc;
using static exe1.Dto.DtoRandom;

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController:ControllerBase
    {
        private readonly IRandomService service;
        public RandomController(IRandomService service)
        {
            this.service = service;
        }
        [HttpGet("TheRandom/{prizeId}")]
        public async Task<User> TheRandom(int prizeId)
        {
            try { 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; 
            }
            return await service.TheRandom(prizeId);
        }
        [HttpGet("GetWinnerReport")]
        public async Task<IEnumerable<DtoWinnersReport>> GetWinnerReport()
        {
            return await service.GetWinnerReport();
        }
    }
}