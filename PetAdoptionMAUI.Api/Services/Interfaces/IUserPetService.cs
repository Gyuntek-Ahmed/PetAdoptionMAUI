using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services.Interfaces
{
    public interface IUserPetService
    {
        Task<ApiResponse> AdoptPetAsync(int userId, int petId);
        Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync(int userId);
        Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync(int userId);
        Task<ApiResponse> ToggleFavoritiesAsync(int userId, int petId);
    }
}