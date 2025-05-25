using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Request;
using PetAdoptionMAUI.Shared.Dtos.Response;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<Shared.Dtos.Response.ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);

        [Post("/api/auth/register")]
        Task<Shared.Dtos.Response.ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}
