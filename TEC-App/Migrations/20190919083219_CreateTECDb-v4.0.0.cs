using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTECDbv400 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Qualification");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Qualification",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Qualification",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Qualification",
                nullable: true);
        }
    }
}
