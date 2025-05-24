using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared.Dtos;
using System.Linq.Expressions;

namespace PetAdoptionMAUI.Api.Extensions
{
    public static class Selectors
    {
        public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
            p => new PetListDto
            {
                Id = p.Id,
                Name = p.Name,
                Breed = p.Breed,
                Image = p.Image,
                Price = p.Price
            };
    }
}
