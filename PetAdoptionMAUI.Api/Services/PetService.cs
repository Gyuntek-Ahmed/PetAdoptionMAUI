using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Extensions;
using PetAdoptionMAUI.Api.Services.Interfaces;
using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Api.Services
{
    public class PetService : IPetService
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
                .OrderByDescending(p => p.Views)
                .Take(count)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count)
        {
            var pets = await _context.Pets
                .OrderByDescending(_ => Guid.NewGuid())
                .Take(count)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetAllPetsAsync()
        {
            var pets = await _context.Pets
                .OrderByDescending(p => p.Id)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetDetailsDto>> GetPetDetailsAsync(int petId)
        {
            var petDetails = await _context.Pets
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == petId);

            if (petDetails is not null)
            {
                petDetails.Views++;
                _context.SaveChanges();
            }

            var petDto = petDetails!.MapToPetDetailsDto();

            return ApiResponse<PetDetailsDto>.Success(petDto);
        }
    }
}
