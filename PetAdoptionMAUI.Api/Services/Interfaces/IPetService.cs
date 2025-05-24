using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services.Interfaces
{
    public interface IPetService
    {
        Task<ApiResponse<PetListDto[]>> GetAllPetsAsync();
        Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count);
        Task<ApiResponse<PetDetailsDto>> GetPetDetailsAsync(int petId);
        Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count);
        Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count);
    }
}