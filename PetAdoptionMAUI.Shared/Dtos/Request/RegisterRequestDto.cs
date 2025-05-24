using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMAUI.Shared.Dtos.Request
{
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
