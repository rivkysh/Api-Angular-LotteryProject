using exe1.Dto;
using exe1.Models;

namespace exe1.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> Register(RegiterDto regiterDto);
        Task<LoginResponseDto?> AuthenticateAsync(string userName, string password);
    }
}