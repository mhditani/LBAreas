using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LBAreas.Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d99c20c-987a-483c-8788-90670258c672"), "Easy" },
                    { new Guid("bbbf1c33-df7d-4721-9547-111644ac8bb1"), "Medium" },
                    { new Guid("d3045da1-c6b6-4267-a908-c2c9264e67ff"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0dd644b9-0675-47da-bcb5-9b97c6c7ba6f"), "ML", " Mount Lebanon", "https://mountainsmagleb.com/wp-content/uploads/2020/03/Mount-Kneisse-Mario-Fares-300x225.jpg" },
                    { new Guid("29399f0e-6a9b-40ed-9e3e-a4d1b8d5d1d7"), "NB", "North Lebanon", "https://i.ytimg.com/vi/39qYU5MC_M0/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLBz5cYN1W-0IIQT36IqUZ1tiP3jeA" },
                    { new Guid("7414847b-b57a-4d50-8a72-bf4dce5606e6"), "BH", "Baalbeck-Hermel", "https://media.safarway.com/content/f5370e10-51c9-46b6-8694-ae8df0df1805_sm.jpg" },
                    { new Guid("b453ec82-345b-4761-ba87-a6d6222f6d0b"), "AR", "Akkar", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIQwWSZKnnDMLL3fq_6bDn1x1UeTi0wLTrpg&s" },
                    { new Guid("f27e7f6f-cd6a-497f-b2ec-066ee21b86db"), "BA", "Bekaa", "https://www.wine-searcher.com/images/region/bekaa-valley-7088-1-3.jpg" },
                    { new Guid("fe6734b6-1b1a-490f-8a66-8ac6458347f8"), "SB", "South Lebanon", "https://i.pinimg.com/236x/5c/b8/88/5cb8883d65f0c9db94bc208cd2982750.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3d99c20c-987a-483c-8788-90670258c672"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bbbf1c33-df7d-4721-9547-111644ac8bb1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d3045da1-c6b6-4267-a908-c2c9264e67ff"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0dd644b9-0675-47da-bcb5-9b97c6c7ba6f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("29399f0e-6a9b-40ed-9e3e-a4d1b8d5d1d7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7414847b-b57a-4d50-8a72-bf4dce5606e6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b453ec82-345b-4761-ba87-a6d6222f6d0b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f27e7f6f-cd6a-497f-b2ec-066ee21b86db"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fe6734b6-1b1a-490f-8a66-8ac6458347f8"));
        }
    }
}
