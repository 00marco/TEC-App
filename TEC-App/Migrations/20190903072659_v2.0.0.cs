using Microsoft.EntityFrameworkCore.Migrations;

namespace TEC_App.Migrations
{
    public partial class v200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrerequisitesForCourses",
                table: "PrerequisitesForCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Placements",
                table: "Placements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Openings",
                table: "Openings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateQualifications",
                table: "CandidateQualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate_Session_Pairs",
                table: "Candidate_Session_Pairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

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
                name: "QualificationId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "Session");

            migrationBuilder.RenameTable(
                name: "Qualifications",
                newName: "Qualification");

            migrationBuilder.RenameTable(
                name: "PrerequisitesForCourses",
                newName: "PrerequisitesForCourse");

            migrationBuilder.RenameTable(
                name: "Placements",
                newName: "Placement");

            migrationBuilder.RenameTable(
                name: "Openings",
                newName: "Opening");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "JobHistories",
                newName: "JobHistory");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameTable(
                name: "CandidateQualifications",
                newName: "Candidate_Qualification");

            migrationBuilder.RenameTable(
                name: "Candidate_Session_Pairs",
                newName: "Candidate_Session");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Names",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Qualification",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Qualification",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Qualification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpeningId",
                table: "Qualification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Placement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PlacementId",
                table: "Opening",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Job",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobHistoryId",
                table: "Job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Company",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Candidate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrerequisitesForCourse",
                table: "PrerequisitesForCourse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Placement",
                table: "Placement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opening",
                table: "Opening",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistory",
                table: "JobHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate_Qualification",
                table: "Candidate_Qualification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate_Session",
                table: "Candidate_Session",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Names_CandidateId",
                table: "Names",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SessionId",
                table: "Locations",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesQualifiedForOpening_CandidateId",
                table: "CandidatesQualifiedForOpening",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesQualifiedForOpening_OpeningId",
                table: "CandidatesQualifiedForOpening",
                column: "OpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_CourseId",
                table: "Session",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_CourseId",
                table: "Qualification",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_OpeningId",
                table: "Qualification",
                column: "OpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrerequisitesForCourse_CourseId",
                table: "PrerequisitesForCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PrerequisitesForCourse_QualificationId",
                table: "PrerequisitesForCourse",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_CandidateId",
                table: "Placement",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Opening_CompanyId",
                table: "Opening",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Opening_PlacementId",
                table: "Opening",
                column: "PlacementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobHistoryId",
                table: "Job",
                column: "JobHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_CandidateId",
                table: "JobHistory",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_CompanyId",
                table: "JobHistory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_AddressId",
                table: "Candidate",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Qualification_CandidateId",
                table: "Candidate_Qualification",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Qualification_QualificationId",
                table: "Candidate_Qualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Session_CandidateId",
                table: "Candidate_Session",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Session_SessionId",
                table: "Candidate_Session",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Address_AddressId",
                table: "Candidate",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Qualification_Candidate_CandidateId",
                table: "Candidate_Qualification",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Qualification_Qualification_QualificationId",
                table: "Candidate_Qualification",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Session_Candidate_CandidateId",
                table: "Candidate_Session",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Session_Session_SessionId",
                table: "Candidate_Session",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesQualifiedForOpening_Candidate_CandidateId",
                table: "CandidatesQualifiedForOpening",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesQualifiedForOpening_Opening_OpeningId",
                table: "CandidatesQualifiedForOpening",
                column: "OpeningId",
                principalTable: "Opening",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobHistory_JobHistoryId",
                table: "Job",
                column: "JobHistoryId",
                principalTable: "JobHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistory_Candidate_CandidateId",
                table: "JobHistory",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistory_Company_CompanyId",
                table: "JobHistory",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressId",
                table: "Locations",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Session_SessionId",
                table: "Locations",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Names_Candidate_CandidateId",
                table: "Names",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opening_Company_CompanyId",
                table: "Opening",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opening_Placement_PlacementId",
                table: "Opening",
                column: "PlacementId",
                principalTable: "Placement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Placement_Candidate_CandidateId",
            //    table: "Placement",
            //    column: "CandidateId",
            //    principalTable: "Candidate",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrerequisitesForCourse_Course_CourseId",
                table: "PrerequisitesForCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrerequisitesForCourse_Qualification_QualificationId",
                table: "PrerequisitesForCourse",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_Course_CourseId",
                table: "Qualification",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_Opening_OpeningId",
                table: "Qualification",
                column: "OpeningId",
                principalTable: "Opening",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Course_CourseId",
                table: "Session",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Address_AddressId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Qualification_Candidate_CandidateId",
                table: "Candidate_Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Qualification_Qualification_QualificationId",
                table: "Candidate_Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Session_Candidate_CandidateId",
                table: "Candidate_Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Session_Session_SessionId",
                table: "Candidate_Session");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesQualifiedForOpening_Candidate_CandidateId",
                table: "CandidatesQualifiedForOpening");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesQualifiedForOpening_Opening_OpeningId",
                table: "CandidatesQualifiedForOpening");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobHistory_JobHistoryId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistory_Candidate_CandidateId",
                table: "JobHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_JobHistory_Company_CompanyId",
                table: "JobHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Session_SessionId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Names_Candidate_CandidateId",
                table: "Names");

            migrationBuilder.DropForeignKey(
                name: "FK_Opening_Company_CompanyId",
                table: "Opening");

            migrationBuilder.DropForeignKey(
                name: "FK_Opening_Placement_PlacementId",
                table: "Opening");

            migrationBuilder.DropForeignKey(
                name: "FK_Placement_Candidate_CandidateId",
                table: "Placement");

            migrationBuilder.DropForeignKey(
                name: "FK_PrerequisitesForCourse_Course_CourseId",
                table: "PrerequisitesForCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_PrerequisitesForCourse_Qualification_QualificationId",
                table: "PrerequisitesForCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_Course_CourseId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_Opening_OpeningId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Course_CourseId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Names_CandidateId",
                table: "Names");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_SessionId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesQualifiedForOpening_CandidateId",
                table: "CandidatesQualifiedForOpening");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesQualifiedForOpening_OpeningId",
                table: "CandidatesQualifiedForOpening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_CourseId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification");

            migrationBuilder.DropIndex(
                name: "IX_Qualification_CourseId",
                table: "Qualification");

            migrationBuilder.DropIndex(
                name: "IX_Qualification_OpeningId",
                table: "Qualification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrerequisitesForCourse",
                table: "PrerequisitesForCourse");

            migrationBuilder.DropIndex(
                name: "IX_PrerequisitesForCourse_CourseId",
                table: "PrerequisitesForCourse");

            migrationBuilder.DropIndex(
                name: "IX_PrerequisitesForCourse_QualificationId",
                table: "PrerequisitesForCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Placement",
                table: "Placement");

            migrationBuilder.DropIndex(
                name: "IX_Placement_CandidateId",
                table: "Placement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opening",
                table: "Opening");

            migrationBuilder.DropIndex(
                name: "IX_Opening_CompanyId",
                table: "Opening");

            migrationBuilder.DropIndex(
                name: "IX_Opening_PlacementId",
                table: "Opening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistory",
                table: "JobHistory");

            migrationBuilder.DropIndex(
                name: "IX_JobHistory_CandidateId",
                table: "JobHistory");

            migrationBuilder.DropIndex(
                name: "IX_JobHistory_CompanyId",
                table: "JobHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobHistoryId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate_Session",
                table: "Candidate_Session");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_Session_CandidateId",
                table: "Candidate_Session");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_Session_SessionId",
                table: "Candidate_Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate_Qualification",
                table: "Candidate_Qualification");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_Qualification_CandidateId",
                table: "Candidate_Qualification");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_Qualification_QualificationId",
                table: "Candidate_Qualification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_AddressId",
                table: "Candidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Names");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "OpeningId",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Opening");

            migrationBuilder.DropColumn(
                name: "JobHistoryId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Session",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "Qualification",
                newName: "Qualifications");

            migrationBuilder.RenameTable(
                name: "PrerequisitesForCourse",
                newName: "PrerequisitesForCourses");

            migrationBuilder.RenameTable(
                name: "Placement",
                newName: "Placements");

            migrationBuilder.RenameTable(
                name: "Opening",
                newName: "Openings");

            migrationBuilder.RenameTable(
                name: "JobHistory",
                newName: "JobHistories");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Candidate_Session",
                newName: "Candidate_Session_Pairs");

            migrationBuilder.RenameTable(
                name: "Candidate_Qualification",
                newName: "CandidateQualifications");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Qualifications",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Qualifications",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Placements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Jobs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrerequisitesForCourses",
                table: "PrerequisitesForCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Placements",
                table: "Placements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Openings",
                table: "Openings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate_Session_Pairs",
                table: "Candidate_Session_Pairs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateQualifications",
                table: "CandidateQualifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");
        }
    }
}
