using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTECDbv800 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Qualification_QualificationId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_QualificationId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_QualificationId",
                table: "Course",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Qualification_QualificationId",
                table: "Course",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
