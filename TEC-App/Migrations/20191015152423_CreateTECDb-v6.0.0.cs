using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTECDbv600 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Candidate",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Candidate");
        }
    }
}
