using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using exe1.Services;
using System.Numerics;

namespace exe1.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository repository, ITokenService tokenService, IConfiguration configuration)
        {
            this.repository = repository;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }
        //Register
        public async Task<UserResponseDto> Register(RegiterDto regiterDto)
        {
            User user = new User();
            user.Name = regiterDto.Name;
            user.UserName = regiterDto.UserName;
            user.PhoneNumber = regiterDto.PhoneNumber;
            user.Email = regiterDto.Email;
            user.Password = HashPassword(regiterDto.Password);
            var u = await repository.CreatUser(user);
            UserResponseDto userResponseDto = new UserResponseDto();
            userResponseDto.Id = user.Id;
            userResponseDto.Name = user.Name;
            userResponseDto.UserName = user.UserName;
            userResponseDto.PhoneNumber = user.PhoneNumber;
            userResponseDto.Email = user.Email;
            return userResponseDto;

        }
        public async Task<LoginResponseDto?> AuthenticateAsync(string userName, string password)
        {
            var user = await repository.GetByUserName(userName);

            if (user == null)
            {
                return null;

            }

            var hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword)
            {
                return null;
            }

            var token = tokenService.GenerateToken(user.Id, user.Email, user.Name, user.UserName,user.Role);
            var expiryMinutes = configuration.GetValue<int>("JwtSettings:ExpiryMinutes", 60);

            UserResponseDto userResponseDto = new()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
                
                
            };
            return new LoginResponseDto
            {
                Token = token,
                TokenType = "Bearer",
                ExpiresIn = expiryMinutes * 60,
                User = userResponseDto,
                Role = user.Role
            };

        }
        private static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
