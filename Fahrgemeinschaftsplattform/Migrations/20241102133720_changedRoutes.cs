using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahrgemeinschaftsplattform.Migrations
{
    /// <inheritdoc />
    public partial class changedRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FahrerName",
                table: "Routen");

            migrationBuilder.DropColumn(
                name: "MitfahrerName",
                table: "Anfragen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FahrerName",
                table: "Routen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MitfahrerName",
                table: "Anfragen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
