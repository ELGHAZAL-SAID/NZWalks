using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class regiondiff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23416337-1ea7-4e1e-ad17-2a6c29f06626"), "Eeasy" },
                    { new Guid("447fffcc-92ce-4cd1-a66b-e848c90cacb2"), "Hard" },
                    { new Guid("637befdf-f78a-4cc9-a17c-e9294257b58f"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("05fcec74-f560-4b25-aa4d-f7043df42f5f"), "LS", "Laayoune Sakia El hamrae", "Image Url" },
                    { new Guid("05fcec74-f560-4b25-ab3d-f7043df42f5f"), "RB", "Rabat Knitra", "Image Url" },
                    { new Guid("0e8cbdd0-108a-4b54-ac00-20cefeed3ad7"), "KB", "Khouribga Bni mlal", "Image Url" },
                    { new Guid("480138fd-7150-4f3d-a02b-d09a5ae4d693"), "FS", "Fes-Mekness", "Image Url" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("23416337-1ea7-4e1e-ad17-2a6c29f06626"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("447fffcc-92ce-4cd1-a66b-e848c90cacb2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("637befdf-f78a-4cc9-a17c-e9294257b58f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("05fcec74-f560-4b25-aa4d-f7043df42f5f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("05fcec74-f560-4b25-ab3d-f7043df42f5f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0e8cbdd0-108a-4b54-ac00-20cefeed3ad7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("480138fd-7150-4f3d-a02b-d09a5ae4d693"));
        }
    }
}
