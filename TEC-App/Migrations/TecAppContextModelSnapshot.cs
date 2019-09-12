﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEC_App.Helpers;

namespace TEC_App.Migrations
{
    [DbContext(typeof(TecAppContext))]
    partial class TecAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TEC_App.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<string>("City");

                    b.Property<int>("LocationId");

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TEC_App.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("TEC_App.Models.Candidate_Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<int>("QualificationId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("QualificationId");

                    b.ToTable("Candidate_Qualification");
                });

            modelBuilder.Entity("TEC_App.Models.Candidate_Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<int>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("SessionId");

                    b.ToTable("Candidate_Session");
                });

            modelBuilder.Entity("TEC_App.Models.CandidatesQualifiedForOpening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<int>("OpeningId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("OpeningId");

                    b.ToTable("CandidatesQualifiedForOpening");
                });

            modelBuilder.Entity("TEC_App.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsIncludedInList");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("TEC_App.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TEC_App.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobHistoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("JobHistoryId")
                        .IsUnique();

                    b.ToTable("Job");
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<int>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobHistory");
                });

            modelBuilder.Entity("TEC_App.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("Capacity");

                    b.Property<int>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TEC_App.Models.Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("TEC_App.Models.Opening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<float>("HourlyPay");

                    b.Property<int>("PlacementId");

                    b.Property<int>("RequiredQualificationId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PlacementId")
                        .IsUnique();

                    b.ToTable("Opening");
                });

            modelBuilder.Entity("TEC_App.Models.Placement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateId");

                    b.Property<int>("OpeningId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Placement");
                });

            modelBuilder.Entity("TEC_App.Models.PrerequisitesForCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("QualificationId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("QualificationId");

                    b.ToTable("PrerequisitesForCourse");
                });

            modelBuilder.Entity("TEC_App.Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Difficulty")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OpeningId");

                    b.Property<int>("SourceCourseId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("OpeningId");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("TEC_App.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<int>("LocationId");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("TEC_App.Models.Candidate", b =>
                {
                    b.HasOne("TEC_App.Models.Address", "Address")
                        .WithOne("Candidate")
                        .HasForeignKey("TEC_App.Models.Candidate", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Candidate_Qualification", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("CandidatesQualifications")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Qualification", "Qualification")
                        .WithMany("CandidatesQualifications")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Candidate_Session", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("Candidate_Session_Pairs")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Session", "Session")
                        .WithMany("Candidate_Sessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.CandidatesQualifiedForOpening", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("QualifiedCandidates")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Opening", "Opening")
                        .WithMany("QualifiedCandidates")
                        .HasForeignKey("OpeningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Job", b =>
                {
                    b.HasOne("TEC_App.Models.JobHistory", "JobHistory")
                        .WithOne("Job")
                        .HasForeignKey("TEC_App.Models.Job", "JobHistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("JobHistories")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Company", "Company")
                        .WithMany("JobHistories")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Location", b =>
                {
                    b.HasOne("TEC_App.Models.Address", "Address")
                        .WithOne("Location")
                        .HasForeignKey("TEC_App.Models.Location", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Session", "Session")
                        .WithOne("Location")
                        .HasForeignKey("TEC_App.Models.Location", "SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Name", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Opening", b =>
                {
                    b.HasOne("TEC_App.Models.Company", "Company")
                        .WithMany("Openings")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Placement", "Placement")
                        .WithOne("Opening")
                        .HasForeignKey("TEC_App.Models.Opening", "PlacementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Placement", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate")
                        .WithMany("Placements")
                        .HasForeignKey("CandidateId");
                });

            modelBuilder.Entity("TEC_App.Models.PrerequisitesForCourse", b =>
                {
                    b.HasOne("TEC_App.Models.Course", "Course")
                        .WithMany("PrerequisitesForCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Qualification", "Qualification")
                        .WithMany("PrerequisitesForCourse")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Qualification", b =>
                {
                    b.HasOne("TEC_App.Models.Course", "Course")
                        .WithMany("Qualifications")
                        .HasForeignKey("CourseId");

                    b.HasOne("TEC_App.Models.Opening", "Opening")
                        .WithMany("Qualifications")
                        .HasForeignKey("OpeningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Session", b =>
                {
                    b.HasOne("TEC_App.Models.Course", "Course")
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
