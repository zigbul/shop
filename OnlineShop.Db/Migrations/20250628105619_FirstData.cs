using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class FirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("09936fa2-1afd-4492-a83d-255d133e7154"), "Тёмная алхимия какао-бобов, растопляющая сердца и волю. Запретный плод сладкоежек.", "/images/chocolate.png", "Шоколад", 250m },
                    { new Guid("32b9a536-015b-4427-88c3-9de5917eb96f"), "Свежий, душистый каравай — основа крестьянского рациона. Скромный, но спасает от голода.", "/images/bread.png", "Хлеб", 55m },
                    { new Guid("590556d8-ba30-454c-8146-9c142bd3ce28"), "Выдержанный, ароматный ломоть — пища аристократов и мышей. Дарует силу и удовольствие.", "/images/cheese.png", "Сыр", 125m },
                    { new Guid("c7cf83f5-3b67-4eff-bbc7-20549504e27f"), "Свежее, парящее молоко — источник жизни и магической силы. Пейте, смертные!", "/images/milk.png", "Молоко", 78m },
                    { new Guid("ea5253da-c1dc-48a9-83da-c942ca3472c6"), "Символ жизни, смерти на сковородке и возрождения в салате.", "/images/egg.png", "Яйцо", 109m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09936fa2-1afd-4492-a83d-255d133e7154"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32b9a536-015b-4427-88c3-9de5917eb96f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("590556d8-ba30-454c-8146-9c142bd3ce28"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7cf83f5-3b67-4eff-bbc7-20549504e27f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea5253da-c1dc-48a9-83da-c942ca3472c6"));
        }
    }
}
