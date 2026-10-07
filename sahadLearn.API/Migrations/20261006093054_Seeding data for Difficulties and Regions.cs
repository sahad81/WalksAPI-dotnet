using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sahadLearn.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Easy" },
                    { new Guid("ea294873-7a8c-4c0f-bfae-5d6a0a3f3a31"), "Medium" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "id", "Code", "RegionImage", "name" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", null, "Bay Of Plenty" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6a0b2d9a14"), "NTL", null, "Northland" },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg", "Nelson" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg", "Wellington" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", null, "Southland" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg", "Auckland" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfae-5d6a0a3f3a31"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6a0b2d9a14"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));
        }
    }
}
