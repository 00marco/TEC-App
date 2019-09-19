using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTECDbv200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_Location");

            migrationBuilder.DropColumn(
                name: "IsIncludedInList",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Location_AddressId",
                table: "Location",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Address_AddressId",
                table: "Location",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Address_AddressId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_AddressId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Location");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncludedInList",
                table: "Company",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Address_Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Location_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Location_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Location_AddressId",
                table: "Address_Location",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Location_LocationId",
                table: "Address_Location",
                column: "LocationId");
        }
    }
}
