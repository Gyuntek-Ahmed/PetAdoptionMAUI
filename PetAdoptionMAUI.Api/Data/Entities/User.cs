using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMAUI.Api.Data.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        //[Required, MaxLength(10)]
        //public string Salt { get; set; } = null!;

        //[Required, MaxLength(100)]
        //public string Hash { get; set; } = null!;

        [Required, MaxLength(10)]
        public string Password { get; set; } = null!;
    }
}
