using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sahadLearn.API.Migrations
{
    /// <inheritdoc />
    public partial class FixWalkForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_Defficaltyid",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_Defficaltyid",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "Defficaltyid",
                table: "Walks");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_difficaltyId",
                table: "Walks",
                column: "difficaltyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_difficaltyId",
                table: "Walks",
                column: "difficaltyId",
                principalTable: "Difficulties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_difficaltyId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_difficaltyId",
                table: "Walks");

            migrationBuilder.AddColumn<Guid>(
                name: "Defficaltyid",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Walks_Defficaltyid",
                table: "Walks",
                column: "Defficaltyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_Defficaltyid",
                table: "Walks",
                column: "Defficaltyid",
                principalTable: "Difficulties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
