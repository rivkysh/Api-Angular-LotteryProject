using exe1.Dto;
using exe1.Models;

namespace exe1.Interfaces
{
    public interface IDonorService
    {
        Task<IEnumerable<Donor>> GetDoners();
        Task<Donor> AddNewDonor(DtoAddDonor dto);
        Task<Donor> UpdateDonor(DtoUpdateDonor dto, int id);
        Task<bool> RemoveDonor(int id);
        Task<IEnumerable<Prize>> GetPrizesByDonor(int id);
        Task<IEnumerable<Donor>> GetDonorByName(string name);
        Task<IEnumerable<Donor>> GetDonorByEmail(string email);
        Task<IEnumerable<Donor>> GetDonorByPrize(string prize);
    }
}