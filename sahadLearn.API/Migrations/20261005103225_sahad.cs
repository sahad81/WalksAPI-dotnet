using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sahadLearn.API.Migrations
{
    /// <inheritdoc />
    public partial class sahad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegthInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    difficaltyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Defficaltyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_Defficaltyid",
                        column: x => x.Defficaltyid,
                        principalTable: "Difficulties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_Defficaltyid",
                table: "Walks",
                column: "Defficaltyid");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionID",
                table: "Walks",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
