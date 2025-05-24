using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Extensions;
using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services
{
    public class PetService
    {
        private readonly PetContext _context;

        public PetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count)
        {
            var pets = await _context.Pets
                .Select(Selectors.PetToPetListDto)
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count)
        {
            var pets = await _context.Pets
                .Select(Selectors.PetToPetListDto)
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }
    }
}
