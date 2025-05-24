using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMAUI.Shared.Dtos.Request
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
