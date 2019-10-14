using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTECDbv500 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Placement_Opening_RequiredQualificationId",
            //    table: "Placement");

            //migrationBuilder.RenameColumn(
            //    name: "RequiredQualificationId",
            //    table: "Placement",
            //    newName: "OpeningId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Placement_RequiredQualificationId",
            //    table: "Placement",
            //    newName: "IX_Placement_OpeningId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Placement_Opening_OpeningId",
            //    table: "Placement",
            //    column: "OpeningId",
            //    principalTable: "Opening",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placement_Opening_OpeningId",
                table: "Placement");

            migrationBuilder.RenameColumn(
                name: "OpeningId",
                table: "Placement",
                newName: "RequiredQualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Placement_OpeningId",
                table: "Placement",
                newName: "IX_Placement_RequiredQualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Placement_Opening_RequiredQualificationId",
                table: "Placement",
                column: "RequiredQualificationId",
                principalTable: "Opening",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
