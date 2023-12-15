using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class DegionToRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Degions_RegionId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degions",
                table: "Degions");

            migrationBuilder.RenameTable(
                name: "Degions",
                newName: "Regions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Degions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degions",
                table: "Degions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Degions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Degions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
