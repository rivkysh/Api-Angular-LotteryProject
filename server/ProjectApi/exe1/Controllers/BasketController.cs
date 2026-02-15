using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;
        public BasketController(IBasketService service)
        {
            this.service = service;
        }

        [HttpGet("GetPurchasesByPrize/{prizeId}")]
        public async Task<IEnumerable<DtoListOrders>> GetPurchasesByPrize(int prizeId)
        {
            return await service.GetPurchasesByPrize(prizeId);
        }
        [HttpGet("TheMostPurchasedPrizes")]
        public async Task<Prize> TheMostPurchasedPrizes()
        {
            return await service.TheMostPurchasedPrizes();
        }
        [HttpGet("theMostExpensivePrize")]
        public async Task<Prize> theMostExpensivePrize()
        {
            return await service.theMostExpensivePrize();
        }

        [HttpPost("AddPrizeToBasket/{PrizeId}")]
        [Authorize]
        public async Task<string> AddPrizeToBasket(int PrizeId)
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return "משתמש לא מורשה";
            int userId = int.Parse(userIdClaim.Value);
           return await service.AddPrizeToBasket( PrizeId, userId);
        }
        //GetBasketOfUser
        [HttpGet("GetBasketOfUser")]
        public async Task<Basket> GetBasketOfUser()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return null;
           int userId = int.Parse(userIdClaim.Value);
            return await service.GetBasketOfUser(userId);
        }
        //CompleteOrder
        [HttpPost("CompleteOrder")]
        [Authorize]
        public async Task<string> CompleteOrder()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return "משתמש לא מורשה";
            int userId = int.Parse(userIdClaim.Value);
            return  await service.CompleteOrder( userId);

        }
        //DeletePrizeFromBasket
        [HttpDelete("DeletePrizeFromBasket/{prizeId}")]
        [Authorize]
        public async Task<string> DeletePrizeFromBasket(int prizeId)
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return "משתמש לא מורשה";
            int userId = int.Parse(userIdClaim.Value);
            return await service.DeletePrizeFromBasket(prizeId, userId);
        }

    }
}