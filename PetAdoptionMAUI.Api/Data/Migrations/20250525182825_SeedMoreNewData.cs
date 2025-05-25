using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoptionMAUI.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Дружелюбна и енергична, Бела обича да играе и да прави дълги разходки. Тя се разбира чудесно с деца и други домашни любимци.", "Бела" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Макс е спокоен и любящ булдог. Обича да се излежава наоколо и е много лоялен към семейството си.", "Макс" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чарли е любопитен и игрив бигъл. Обича да изследва и е много приятелски настроен към всеки, когото срещне.", "Чарли" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Люси е красива сиамска котка с поразително сини очи. Тя е независима, но обича да се гушка, когато е в настроение.", "Люси" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Майло е пухкава котка, която обича да се излежава на слънчеви места. Той е кротък и обича да бъде глезен.", "Майло" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Breed", "DateOfBirth", "Description", "Name" },
                values: new object[] { "Bulldog", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дейзи е игрив и дружелюбен лабрадор. Обича водата и обича да плува в езерото.", "Дейзи" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роки е силна и интелигентна немска овчарка. Той защитава семейството си и обича да играе.", "Роки" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Луна е жив и разговорлив сенегалски папагал. Тя обича да имитира звуци и обича да общува с хора.", "Луна" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdpotionStatus", "Breed", "Category", "DateOfBirth", "Description", "Gender", "Image", "IsActive", "Name", "Price", "Views" },
                values: new object[,]
                {
                    { 9, 1, "Cockatiel", 2, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco е сладък и дружелюбен коктейл. Обича да пее и да танцува, когато чуе музика.", 0, "bird1.jpg", true, "Coco", 180.0, 0 },
                    { 10, 1, "Lark", 2, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бъни е сладък и пухкав. Обича да играе с играчките си. Идеален домашен любимец за деца.", 0, "bird2.jpg", true, "Бъни", 50.0, 0 },
                    { 11, 1, "Sparrow", 2, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Снежи е енергична и игрива. Обича да подскача и да играе с деца.", 1, "bird3.jpg", true, "Снежи", 400.0, 0 },
                    { 12, 1, "Българска котка", 1, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Блу е мила и игрива българска котка. Тя обича да се гушка и да играе с топки.", 1, "cat3.jpg", true, "Блу", 120.0, 0 },
                    { 13, 1, "Българска котка", 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Том е дружелюбен и игрив български котарак. Той обича да се разхожда наоколо и да изследва.", 0, "cat4.jpg", true, "Том", 130.0, 0 },
                    { 14, 1, "Българска котка", 1, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фреди е пухкав и игрив български котарак. Той обича да се гушка и да играе с деца.", 0, "cat5.jpg", true, "Фреди", 140.0, 0 },
                    { 15, 1, "Българска котка", 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Зара е мила и игрива българска котка. Тя обича да се гушка и да играе с топки.", 1, "cat6.jpg", true, "Зара", 110.0, 0 },
                    { 16, 1, "Българска котка", 1, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бобо е дружелюбен и игрив български котарак. Той обича да се разхожда наоколо и да изследва.", 0, "cat7.jpg", true, "Бобо", 115.0, 0 },
                    { 17, 1, "Пухкава Снежинка", 0, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Снежинка е пухкава и игрива българско куче. Обича да се гушка и да играе с деца.", 1, "dog4.jpg", true, "Снежинка", 125.0, 0 },
                    { 18, 1, "Океанска Риба", 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бобо е красива океанска риба с ярки цветове. Той е спокоен и обича да плува в аквариума.", 0, "fish1.jpg", true, "Бобо", 300.0, 0 },
                    { 19, 1, "Златна Рибка", 3, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Златко е класическа златна рибка с блестящи люспи. Тя е спокойна и обича да плува в аквариума.", 0, "fish2.jpg", true, "Златко", 150.0, 0 },
                    { 20, 1, "Тропическа Риба", 3, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Поко е ярка и цветна тропическа риба. Тя обича да плува в аквариума и да се наслаждава на топлата вода.", 0, "fish3.jpg", true, "Поко", 200.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Friendly and energetic, Bella loves to play fetch and go for long walks. She's great with kids and other pets.", "Bella" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Max is a calm and affectionate bulldog. He enjoys lounging around and is very loyal to his family.", "Max" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie is a curious and playful beagle. He loves to explore and is very friendly with everyone he meets.", "Charlie" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy is a beautiful Siamese cat with striking blue eyes. She's independent but loves to cuddle when she's in the mood.", "Lucy" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milo is a fluffy Persian cat who enjoys lounging in sunny spots. He's gentle and loves being pampered.", "Milo" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Breed", "DateOfBirth", "Description", "Name" },
                values: new object[] { "Labrador Retriever", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy is a playful and friendly Labrador. She loves water and enjoys swimming in the lake.", "Daisy" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is a strong and intelligent German Shepherd. He's protective of his family and loves to play fetch.", "Rocky" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Description", "Name" },
                values: new object[] { new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna is a vibrant and talkative Senegal parrot. She loves to mimic sounds and enjoys interacting with people.", "Luna" });
        }
    }
}
