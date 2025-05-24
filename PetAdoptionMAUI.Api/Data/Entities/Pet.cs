using PetAdoptionMAUI.Shared.Enumarations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoptionMAUI.Api.Data.Entities
{
    public class Pet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(180)]
        public string Image { get; set; } = null!;

        [MaxLength(50)]
        public string? Breed { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required, Range(0, double.MaxValue)]
        public double Price { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public int Views { get; set; }

        public AdpotionStatus AdpotionStatus { get; set; } = AdpotionStatus.Available;

        public bool IsActive { get; set; } = true;
    }
}
