using exe1.Dto;
using exe1.Models;
using Microsoft.AspNetCore.Mvc;

namespace exe1.Interfaces;

public interface IPrizeService
{
    Task<IEnumerable<Prize>> GetPrize();
    Task<Prize> GetPrizeById(int id);
    Task<Prize> AddNewPrize(DtoInsertPrize dto);
    Task<bool> RemovePrize(int id);
    Task<Prize?> UpdatePrize(int id, PrizeUpdateDto dto);
    Task<DtoDonerDatalies>? GetDonorByPrizeId(int prizeId);
    Task<ActionResult<IEnumerable<Prize>>> GetListPrizesByCategory(string category);
}