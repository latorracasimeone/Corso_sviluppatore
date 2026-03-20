using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rubrica.Api.Migrations
{
    /// <inheritdoc />
    public partial class RimozioneCampiInEccesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canzone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cap",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Canzone",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cap",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Film",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
