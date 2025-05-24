using PetAdoptionMAUI.Shared.Enumarations;

namespace PetAdoptionMAUI.Shared.Dtos
{
    public class PetDetailsDto : PetListDto
    {
        public bool IsFavorite { get; set; }

        public string Description { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public Category Category { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AdpotionStatus AdpotionStatus { get; set; }

        public string GenderDisplay => Gender.ToString();

        public string GenderImage => Gender switch { Gender.Male => "male", Gender.Female => "female", _ => "Unknown" };

        public string CategoryDisplay => Category.ToString();

        public string CategoryImage => Category switch
        {
            Category.Dog => "dog",
            Category.Cat => "cat",
            Category.Bird => "bird",
            Category.Fish => "fish",
            _ => "Unknown"
        };

        public string Age
        {
            get
            {
                var diff = DateTime.Now.Subtract(DateOfBirth);
                var days = diff.Days;

                return days switch
                {
                    < 30 => days + " days",
                    >= 30 and <= 31 => "1 month",
                    < 365 => Math.Floor(diff.TotalDays / 30) + " months",
                    >= 365 and < 730 => "1 year",
                    _ => Math.Floor(diff.TotalDays / 365) + " years"
                };
            }
        }
    }
}
