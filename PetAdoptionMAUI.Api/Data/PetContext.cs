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
                    Name = "Бела",
                    Breed = "Golden Retriever",
                    Price = 300,
                    Description = "Дружелюбна и енергична, Бела обича да играе и да прави дълги разходки. Тя се разбира чудесно с деца и други домашни любимци.",
                    Image = "bella.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2025, 2, 15),
                },
                new Pet
                {
                    Id = 6,
                    Name = "Дейзи",
                    Breed = "Bulldog",
                    Price = 320,
                    Description = "Дейзи е игрив и дружелюбен лабрадор. Обича водата и обича да плува в езерото.",
                    Image = "dog3.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 6, 1),
                },
                new Pet
                {
                    Id = 2,
                    Name = "Макс",
                    Breed = "Bulldog",
                    Price = 250,
                    Description = "Макс е спокоен и любящ булдог. Обича да се излежава наоколо и е много лоялен към семейството си.",
                    Image = "dog1.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 3, 5),
                },
                new Pet
                {
                    Id = 3,
                    Name = "Чарли",
                    Breed = "Beagle",
                    Price = 200,
                    Description = "Чарли е любопитен и игрив бигъл. Обича да изследва и е много приятелски настроен към всеки, когото срещне.",
                    Image = "dog2.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 5, 10),
                },
                new Pet
                {
                    Id = 4,
                    Name = "Люси",
                    Breed = "Siamese Cat",
                    Price = 150,
                    Description = "Люси е красива сиамска котка с поразително сини очи. Тя е независима, но обича да се гушка, когато е в настроение.",
                    Image = "cat1.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 1, 15),
                },
                new Pet
                {
                    Id = 5,
                    Name = "Майло",
                    Breed = "Persian Cat",
                    Price = 180,
                    Description = "Майло е пухкава котка, която обича да се излежава на слънчеви места. Той е кротък и обича да бъде глезен.",
                    Image = "cat2.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 8, 20),
                },
                new Pet
                {
                    Id = 7,
                    Name = "Роки",
                    Breed = "German Shepherd",
                    Price = 350,
                    Description = "Роки е силна и интелигентна немска овчарка. Той защитава семейството си и обича да играе.",
                    Image = "germanShepard.jpg",
                    Category = Category.Dog,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2025, 3, 3),
                },
                new Pet
                {
                    Id = 8,
                    Name = "Луна",
                    Breed = "Senegal parrot",
                    Price = 400,
                    Description = "Луна е жив и разговорлив сенегалски папагал. Тя обича да имитира звуци и обича да общува с хора.",
                    Image = "senegalParrot.jpg",
                    Category = Category.Bird,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 5, 15),
                },
                new Pet
                {
                    Id = 9,
                    Name = "Coco",
                    Breed = "Cockatiel",
                    Price = 180,
                    Description = "Coco е сладък и дружелюбен коктейл. Обича да пее и да танцува, когато чуе музика.",
                    Image = "bird1.jpg",
                    Category = Category.Bird,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 7, 10),
                },
                new Pet
                {
                    Id = 10,
                    Name = "Бъни",
                    Breed = "Lark",
                    Price = 50,
                    Description = "Бъни е сладък и пухкав. Обича да играе с играчките си. Идеален домашен любимец за деца.",
                    Image = "bird2.jpg",
                    Category = Category.Bird,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 4, 25),
                },
                new Pet
                {
                    Id = 11,
                    Name = "Снежи",
                    Breed = "Sparrow",
                    Price = 400,
                    Description = "Снежи е енергична и игрива. Обича да подскача и да играе с деца.",
                    Image = "bird3.jpg",
                    Category = Category.Bird,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 9, 1),
                },
                new Pet
                {
                    Id = 12,
                    Name = "Блу",
                    Breed = "Българска котка",
                    Price = 120,
                    Description = "Блу е мила и игрива българска котка. Тя обича да се гушка и да играе с топки.",
                    Image = "cat3.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2024, 10, 5),
                },
                new Pet
                {
                    Id = 13,
                    Name = "Том",
                    Breed = "Българска котка",
                    Price = 130,
                    Description = "Том е дружелюбен и игрив български котарак. Той обича да се разхожда наоколо и да изследва.",
                    Image = "cat4.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 11, 20),
                },
                new Pet
                {
                    Id = 14,
                    Name = "Фреди",
                    Breed = "Българска котка",
                    Price = 140,
                    Description = "Фреди е пухкав и игрив български котарак. Той обича да се гушка и да играе с деца.",
                    Image = "cat5.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2024, 12, 15),
                },
                new Pet
                {
                    Id = 15,
                    Name = "Зара",
                    Breed = "Българска котка",
                    Price = 110,
                    Description = "Зара е мила и игрива българска котка. Тя обича да се гушка и да играе с топки.",
                    Image = "cat6.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2025, 1, 10),
                },
                new Pet
                {
                    Id = 16,
                    Name = "Бобо",
                    Breed = "Българска котка",
                    Price = 115,
                    Description = "Бобо е дружелюбен и игрив български котарак. Той обича да се разхожда наоколо и да изследва.",
                    Image = "cat7.jpg",
                    Category = Category.Cat,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2025, 2, 5),
                },
                new Pet
                {
                     Id = 17,
                     Name = "Снежинка",
                     Breed = "Пухкава Снежинка",
                     Price = 125,
                     Description = "Снежинка е пухкава и игрива българско куче. Обича да се гушка и да играе с деца.",
                     Image = "dog4.jpg",
                     Category = Category.Dog,
                     Gender = Gender.Female,
                     DateOfBirth = new DateTime(2025, 3, 1),
                },
                new Pet
                {
                    Id = 18,
                    Name = "Бобо",
                    Breed = "Океанска Риба",
                    Price = 300,
                    Description = "Бобо е красива океанска риба с ярки цветове. Той е спокоен и обича да плува в аквариума.",
                    Image = "fish1.jpg",
                    Category = Category.Fish,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2025, 4, 10),
                },
                new Pet
                {
                    Id = 19,
                    Name = "Златко",
                    Breed = "Златна Рибка",
                    Price = 150,
                    Description = "Златко е класическа златна рибка с блестящи люспи. Тя е спокойна и обича да плува в аквариума.",
                    Image = "fish2.jpg",
                    Category = Category.Fish,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2025, 5, 20),
                },
                new Pet
                {
                    Id = 20,
                    Name = "Поко",
                    Breed = "Тропическа Риба",
                    Price = 200,
                    Description = "Поко е ярка и цветна тропическа риба. Тя обича да плува в аквариума и да се наслаждава на топлата вода.",
                    Image = "fish3.jpg",
                    Category = Category.Fish,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2025, 6, 15),
                }
            };
            return pets;
        }
    }
}
