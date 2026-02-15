using exe1.Dto;
using exe1.Models;
using Microsoft.AspNetCore.Mvc;

namespace exe1.Interfaces;

public interface IPrizeRepository
{
    Task<IEnumerable<Prize>> GetPrize();
    Task<Prize> GetPrizeById(int id);
    Task AddNewPrize(Prize prize);
    Task<bool> RemovePrize(int id);
    Task SaveUpdate(Prize prize);
    Task<Donor>? GetDonorByPrizeId(int prizeId);
    Task<ActionResult<IEnumerable<Prize>>> GetListPrizesByCategory(string category);
}