namespace PetAdoptionMAUI.Shared.Dtos
{
    public class PetListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public double Price { get; set; }

        public string Breed { get; set; } = null!;
    }
}
