using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data;
using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Api.Extensions;
using PetAdoptionMAUI.Api.Services.Interfaces;
using PetAdoptionMAUI.Shared.Dtos;
using PetAdoptionMAUI.Shared.Dtos.Response;
using PetAdoptionMAUI.Shared.Enumarations;

namespace PetAdoptionMAUI.Api.Services
{
    public class UserPetService : IUserPetService
    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly PetContext _context;

        public UserPetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> ToggleFavoritiesAsync(int userId, int petId)
        {
            var userFavorites = await _context.UserFavorites
                .FirstOrDefaultAsync(uf => uf.UserId == userId && uf.PetId == petId);

            if (userFavorites is not null)
                _context.UserFavorites.Remove(userFavorites);
            else
            {
                userFavorites = new UserFavorites
                {
                    UserId = userId,
                    PetId = petId
                };

                await _context.UserFavorites.AddAsync(userFavorites);
            }

            await _context.SaveChangesAsync();
            return ApiResponse.Success();
        }

        public async Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync(int userId)
        {
            var pets = await _context.UserFavorites
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.Pet)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync(int userId)
        {
            var pets = await _context.UserAdoptions
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.Pet)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse> AdoptPetAsync(int userId, int petId)
        {
            try
            {
                await _semaphore.WaitAsync();
                // TODO: Take only active and available pets
                var pet = await _context.Pets
                .AsNoTracking()
                //.Where(p => p.IsActive && p.AdpotionStatus == AdpotionStatus.Available)
                .FirstOrDefaultAsync(p => p.Id == petId);

                if (pet is null)
                    return ApiResponse.Fail("Животното не е намерено!");

                if (pet.AdpotionStatus == AdpotionStatus.Adopted)
                    return ApiResponse.Fail($"{pet.Name} вече е осиновено!");

                if (pet.AdpotionStatus == AdpotionStatus.Pending)
                    return ApiResponse.Fail($"{pet.Name} вече е в процес на осиновяване!");

                pet.AdpotionStatus = AdpotionStatus.Adopted;

                var userAdoption = new UserAdoption
                {
                    UserId = userId,
                    PetId = petId,
                    AdoptionDate = DateTime.UtcNow
                };

                await _context.UserAdoptions.AddAsync(userAdoption);
                await _context.SaveChangesAsync();

                return ApiResponse.Success($"{pet.Name} е успешно осиновено!");
            }
            catch (Exception ex)
            {
                return ApiResponse.Fail($"Грешка при осиновяване. {ex.Message}");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
