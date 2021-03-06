﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEC_App.Helpers;

namespace TEC_App.Migrations
{
    [DbContext(typeof(TecAppContext))]
    [Migration("20190919083219_CreateTECDb-v4.0.0")]
    partial class CreateTECDbv400
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("City");

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TEC_App.Models.Address_Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("CandidateId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Address_Candidate");
                });

            modelBuilder.Entity("TEC_App.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

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

            modelBuilder.Entity("TEC_App.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("TEC_App.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("QualificationId");

                    b.HasKey("Id");

                    b.HasIndex("QualificationId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TEC_App.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("JobHistory");
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory_Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("JobHistoryId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobHistoryId");

                    b.ToTable("JobHistory_Company");
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory_Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobHistoryId");

                    b.Property<int>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("JobHistoryId");

                    b.HasIndex("JobId");

                    b.ToTable("JobHistory_Job");
                });

            modelBuilder.Entity("TEC_App.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("Capacity");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Location");
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

                    b.Property<int>("JobId");

                    b.Property<int>("RequiredQualificationId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobId");

                    b.HasIndex("RequiredQualificationId");

                    b.ToTable("Opening");
                });

            modelBuilder.Entity("TEC_App.Models.Placement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId");

                    b.Property<int>("RequiredQualificationId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("TotalHoursWorked");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("RequiredQualificationId");

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

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("TEC_App.Models.QualificationDevelopedByCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("QualificationId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("QualificationId");

                    b.ToTable("QualificationDevelopedByCourse");
                });

            modelBuilder.Entity("TEC_App.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<int>("NumberOfAttendees");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("TEC_App.Models.Session_Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<int>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SessionId");

                    b.ToTable("Session_Location");
                });

            modelBuilder.Entity("TEC_App.Models.Address_Candidate", b =>
                {
                    b.HasOne("TEC_App.Models.Address", "Address")
                        .WithMany("Address_Candidate_Pairs")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("Addresses")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Candidate_Qualification", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("CandidateQualifications")
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
                        .WithMany("Candidate_Session_Pairs")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Course", b =>
                {
                    b.HasOne("TEC_App.Models.Qualification")
                        .WithMany("Courses")
                        .HasForeignKey("QualificationId");
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("JobHistories")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory_Company", b =>
                {
                    b.HasOne("TEC_App.Models.Company", "Company")
                        .WithMany("JobHistory_Company_Pairs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.JobHistory", "JobHistory")
                        .WithMany("JobHistory_Company_Pairs")
                        .HasForeignKey("JobHistoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.JobHistory_Job", b =>
                {
                    b.HasOne("TEC_App.Models.JobHistory", "JobHistory")
                        .WithMany("JobHistory_Job_Pairs")
                        .HasForeignKey("JobHistoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Job", "Job")
                        .WithMany("JobHistory_Job_Pairs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Location", b =>
                {
                    b.HasOne("TEC_App.Models.Address", "Address")
                        .WithMany("Locations")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Opening", b =>
                {
                    b.HasOne("TEC_App.Models.Company", "Company")
                        .WithMany("Openings")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Job", "Job")
                        .WithMany("Openings")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Qualification", "RequiredQualifications")
                        .WithMany("Openings")
                        .HasForeignKey("RequiredQualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Placement", b =>
                {
                    b.HasOne("TEC_App.Models.Candidate", "Candidate")
                        .WithMany("Placements")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Opening", "Opening")
                        .WithMany("Placements")
                        .HasForeignKey("RequiredQualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("TEC_App.Models.QualificationDevelopedByCourse", b =>
                {
                    b.HasOne("TEC_App.Models.Course", "Course")
                        .WithMany("QualificationsDevelopedByCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Qualification", "Qualification")
                        .WithMany("QualificationsDevelopedByCourse")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Session", b =>
                {
                    b.HasOne("TEC_App.Models.Course", "Course")
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TEC_App.Models.Session_Location", b =>
                {
                    b.HasOne("TEC_App.Models.Location", "Location")
                        .WithMany("Session_Location_Pairs")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TEC_App.Models.Session", "Session")
                        .WithMany("Session_Location_Pairs")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
