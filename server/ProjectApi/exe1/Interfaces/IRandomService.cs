using exe1.Dto;
using exe1.Models;
using static exe1.Dto.DtoRandom;

namespace exe1.Interfaces
{
    public interface IRandomService
    {
        Task<IEnumerable<DtoWinnersReport>> GetWinnerReport();
        Task<User> TheRandom(int prizeId);
    }
}