using PetAdoptionMAUI.Shared.Dtos.Request;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);
        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}