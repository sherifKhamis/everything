using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahrgemeinschaftsplattform.Migrations
{
    /// <inheritdoc />
    public partial class fixedRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anfragen_Mitfahrer_MitfahrerId",
                table: "Anfragen");

            migrationBuilder.DropForeignKey(
                name: "FK_Routen_Fahrer_FahrerId",
                table: "Routen");

            migrationBuilder.AlterColumn<int>(
                name: "FahrerId",
                table: "Routen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FahrerName",
                table: "Routen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MitfahrerId",
                table: "Anfragen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MitfahrerName",
                table: "Anfragen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Anfragen_Mitfahrer_MitfahrerId",
                table: "Anfragen",
                column: "MitfahrerId",
                principalTable: "Mitfahrer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routen_Fahrer_FahrerId",
                table: "Routen",
                column: "FahrerId",
                principalTable: "Fahrer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anfragen_Mitfahrer_MitfahrerId",
                table: "Anfragen");

            migrationBuilder.DropForeignKey(
                name: "FK_Routen_Fahrer_FahrerId",
                table: "Routen");

            migrationBuilder.DropColumn(
                name: "FahrerName",
                table: "Routen");

            migrationBuilder.DropColumn(
                name: "MitfahrerName",
                table: "Anfragen");

            migrationBuilder.AlterColumn<int>(
                name: "FahrerId",
                table: "Routen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MitfahrerId",
                table: "Anfragen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anfragen_Mitfahrer_MitfahrerId",
                table: "Anfragen",
                column: "MitfahrerId",
                principalTable: "Mitfahrer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routen_Fahrer_FahrerId",
                table: "Routen",
                column: "FahrerId",
                principalTable: "Fahrer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
