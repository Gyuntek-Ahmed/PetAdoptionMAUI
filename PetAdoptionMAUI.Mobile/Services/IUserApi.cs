using PetAdoptionMAUI.Shared.Dtos;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services
{
    [Headers("Authorization: Bearer")]
    public interface IUserApi
    {
        [Post("/api/user/adopt/{petId}")]
        Task<Shared.Dtos.Response.ApiResponse> AdoptPetAsync(int petId);

        [Get("/api/user/adoptions")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetUserAdoptionsAsync();

        [Get("/api/user/favorites")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetUserFavoritesAsync();

        [Post("/api/user/favorites/{petId}")]
        Task<Shared.Dtos.Response.ApiResponse> ToggleFavoritiesAsync(int petId);
    }
}
