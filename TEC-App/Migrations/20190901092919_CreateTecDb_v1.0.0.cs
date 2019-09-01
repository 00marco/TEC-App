using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class CreateTecDb_v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEnd",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStart",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Sessions",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceCourseId",
                table: "Qualifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Placements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpeningId",
                table: "Placements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Openings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEnd",
                table: "Openings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStart",
                table: "Openings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "HourlyPay",
                table: "Openings",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RequiredQualificationId",
                table: "Openings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Names",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Names",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Names",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "JobHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEnd",
                table: "JobHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStart",
                table: "JobHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "JobHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsIncludedInList",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "SourceCourseId",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "OpeningId",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "HourlyPay",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "RequiredQualificationId",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Names");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Names");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Names");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobHistories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsIncludedInList",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Addresses");
        }
    }
}
