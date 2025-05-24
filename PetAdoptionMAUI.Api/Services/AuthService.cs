using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Api.Services.Interfaces;
using PetAdoptionMAUI.Shared.Dtos.Request;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly PetContext _context;
        private readonly TokenService _tokenService;

        public AuthService(PetContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (dbUser is null)
                return ApiResponse<AuthResponseDto>.Fail("Потребителят не съществува");

            if (dbUser.Password != dto.Password)
                return ApiResponse<AuthResponseDto>.Fail("Грешна парола");

            var token = _tokenService.GenerateJWT(dbUser);

            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(dbUser.Id, dbUser.Name, token));
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser is not null)
                return ApiResponse<AuthResponseDto>.Fail("Потребител с този имейл вече съществува");

            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password // In a real application, hash the password!
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            // Generate JWT token for the new user
            var token = _tokenService.GenerateJWT(newUser);
            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(newUser.Id, newUser.Name, token));
        }
    }
}
