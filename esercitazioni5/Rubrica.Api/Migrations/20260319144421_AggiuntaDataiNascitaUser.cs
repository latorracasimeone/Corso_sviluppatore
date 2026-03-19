using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rubrica.Api.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaDataiNascitaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");
        }
    }
}
