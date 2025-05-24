using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared.Dtos;

namespace PetAdoptionMAUI.Api.Extensions
{
    public static class Mappers
    {
        public static PetDetailsDto MapToPetDetailsDto(this Pet pet)
            => new PetDetailsDto
            {
                AdpotionStatus = pet.AdpotionStatus,
                Breed = pet.Breed,
                DateOfBirth = pet.DateOfBirth,
                Description = pet.Description,
                Gender = pet.Gender,
                Category = pet.Category,
                Id = pet.Id,
                Name = pet.Name,
                Price = pet.Price,
                Image = pet.Image,
            };
    }
}
