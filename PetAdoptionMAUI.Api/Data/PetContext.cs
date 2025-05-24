using Microsoft.EntityFrameworkCore;
using PetAdoptionMAUI.Api.Data.Entities;
using PetAdoptionMAUI.Shared.Enumarations;

namespace PetAdoptionMAUI.Api.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserFavorites> UserFavorites { get; set; }

        public DbSet<UserAdoption> UserAdoptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                .HasKey(uf => new { uf.UserId, uf.PetId });

            modelBuilder.Entity<Pet>()
                .HasData(InitialPetsData());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        private static List<Pet> InitialPetsData()
        {
            var pets = new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                    Name = "Bella",
                    Breed = "Golden Retriever",
                    Price = 300,
                    Description = "Friendly and energetic, Bella loves to play fetch and go for long walks. She's great with kids and other pets.",
                    Image = "bella.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2025, 2, 15),
                },
                new Pet
                {
                    Id = 2,
                    Name = "Max",
                    Breed = "Bulldog",
                    Price = 250,
                    Description = "Max is a calm and affectionate bulldog. He enjoys lounging around and is very loyal to his family.",
                    Image = "dog1.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 3, 5),
                },
                new Pet
                {
                    Id = 3,
                    Name = "Charlie",
                    Breed = "Beagle",
                    Price = 200,
                    Description = "Charlie is a curious and playful beagle. He loves to explore and is very friendly with everyone he meets.",
                    Image = "dog2.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2021, 5, 10),
                },
                new Pet
                {
                    Id = 4,
                    Name = "Lucy",
                    Breed = "Siamese Cat",
                    Price = 150,
                    Description = "Lucy is a beautiful Siamese cat with striking blue eyes. She's independent but loves to cuddle when she's in the mood.",
                    Image = "cat1.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2022, 1, 15),
                },
                new Pet
                {
                    Id = 5,
                    Name = "Milo",
                    Breed = "Persian Cat",
                    Price = 180,
                    Description = "Milo is a fluffy Persian cat who enjoys lounging in sunny spots. He's gentle and loves being pampered.",
                    Image = "cat2.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2021, 8, 20),
                },
                new Pet
                {
                    Id = 6,
                    Name = "Daisy",
                    Breed = "Labrador Retriever",
                    Price = 320,
                    Description = "Daisy is a playful and friendly Labrador. She loves water and enjoys swimming in the lake.",
                    Image = "dog3.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2020, 6, 1),
                },
                new Pet
                {
                    Id = 7,
                    Name = "Rocky",
                    Breed = "German Shepherd",
                    Price = 350,
                    Description = "Rocky is a strong and intelligent German Shepherd. He's protective of his family and loves to play fetch.",
                    Image = "germanShepard.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2021, 3, 10),
                },
                new Pet
                {
                    Id = 8,
                    Name = "Luna",
                    Breed = "Senegal parrot",
                    Price = 400,
                    Description = "Luna is a vibrant and talkative Senegal parrot. She loves to mimic sounds and enjoys interacting with people.",
                    Image = "senegalParrot.jpg",
                    Category = Category.Bird,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2022, 5, 15),
                }
            };
            return pets;
        }
    }
}
