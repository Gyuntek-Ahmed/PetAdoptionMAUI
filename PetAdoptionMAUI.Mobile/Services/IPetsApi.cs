using PetAdoptionMAUI.Shared.Dtos;
using Refit;

namespace PetAdoptionMAUI.Mobile.Services
{
    public interface IPetsApi
    {
        [Get("/api/pets")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetAllPetsAsync();

        [Get("/api/pets/new/{count:int}")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count);

        [Get("/api/pets/{petId:int}")]
        Task<Shared.Dtos.Response.ApiResponse<PetDetailsDto>> GetPetDetailsAsync(int petId);

        [Get("/api/pets/popular/{count:int}")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count);

        [Get("/api/pets//random/{count:int}")]
        Task<Shared.Dtos.Response.ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count);
    }
}
