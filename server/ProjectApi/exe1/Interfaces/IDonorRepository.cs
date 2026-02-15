using exe1.Models;

namespace exe1.Interfaces
{
    public interface IDonorRepository

    {
        Task<IEnumerable<Donor>> GetDoners();

        Task<Donor> AddNewDonor(Donor donor);

        Task<Donor> GetDonorById(int id);

        Task SaveDonor(Donor donor);

        Task<bool> RemoveDonor(int id);

        Task<IEnumerable<Prize>> GetPrizesByDonor(int id);
        Task<IEnumerable<Donor>> GetDonersWithPrizes();
    }
}