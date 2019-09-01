using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Models;

namespace TEC_App.Helpers
{
	class TecAppContext : DbContext
	{
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<JobHistory> JobHistories { get; set; }
		public DbSet<Opening> Openings { get; set; }
		public DbSet<Placement> Placements { get; set; }
		public DbSet<Qualification> Qualifications { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<PrerequisitesForCourse> PrerequisitesForCourses { get; set; }
		public DbSet<Name> Names { get; set; }
		public DbSet<QualifiedCandidates> QualifiedCandidates { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<CandidateQualification> CandidateQualifications { get; set; }
		public DbSet<Candidate_Session> Candidate_Session_Pairs { get; set; }	


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UL75UB3\SQLEXPRESS;Integrated Security=False;User ID=marpmpulido;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=TEC_Db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Address>(c =>
				{
					c.ToTable("Address");
					c.HasKey(d => d.Id);
					c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
					c.HasMany(d => d.Candidates)
						.WithOne(d => d.Address)
						.HasForeignKey(d => d.AddressId);
					c.HasMany(d=>d.Locations)
						.WithOne(d=>d.Address)
						.HasForeignKey(d=>d.AddressId)
				}
			);

			modelBuilder.Entity<Candidate>(c =>
			{
				c.ToTable("Candidate");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.NameId).IsRequired();
				c.Property(d => d.AddressId).IsRequired();
			});

			modelBuilder.Entity<Candidate_Session>(c =>
			{
				c.ToTable("Candidate_Session");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CandidateId).IsRequired();
				c.Property(d => d.SessionId).IsRequired();
				//TODO setup foreign keys

			});
			modelBuilder.Entity<CandidateQualification>(c =>
			{
				c.ToTable("Candidate_Qualification");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CandidateId).IsRequired();
				c.Property(d => d.QualificationId).IsRequired();
				//TODO setup foreign keys
			});
			modelBuilder.Entity<Company>(c =>
			{
				c.ToTable("Company");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.IsIncludedInList).IsRequired();
				c.Property(d => d.Name).IsRequired();
			});
			modelBuilder.Entity<Course>(c =>
			{
				c.ToTable("Course");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.Name).IsRequired();
				c.Property(d => d.QualificationId).IsRequired();
				//TODO setup foreign keys
			});
			modelBuilder.Entity<Job>(c =>
			{
				c.ToTable("Job");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.Name).IsRequired();
			});
			modelBuilder.Entity<JobHistory>(c =>
			{
				c.ToTable("JobHistory");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CandidateId).IsRequired();
				c.Property(d => d.CompanyId).IsRequired();
				c.Property(d => d.JobId).IsRequired();
				c.Property(d => d.DateTimeEnd).IsRequired();
				c.Property(d => d.DateTimeStart).IsRequired();
				//TODO setup foreign keys
			});
			modelBuilder.Entity<Location>(c =>
			{
				c.ToTable("Locations");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.AddressId).IsRequired();
				c.Property(d => d.Capacity).IsRequired();
				//TODO setup foreign keys
			});
			modelBuilder.Entity<Name>(c =>
			{
				c.ToTable("Name");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Opening>(c =>
			{
				c.ToTable("Opening");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CompanyId).IsRequired();
				c.Property(d => d.DateTimeEnd).IsRequired();
				c.Property(d => d.DateTimeStart).IsRequired();
				c.Property(d => d.HourlyPay).IsRequired();
				//todo setup foreign keys
			});
			modelBuilder.Entity<Placement>(c =>
			{
				c.ToTable("Placement");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CandidateId).IsRequired();
				c.Property(d => d.OpeningId).IsRequired();
				//todo setup foreign keys
			});
			modelBuilder.Entity<PrerequisitesForCourse>(c =>
			{
				c.ToTable("PrerequisitesForCourse");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CourseId).IsRequired();
				c.Property(d => d.QualificationId).IsRequired();
				//todo setup foreign keys
			});
			modelBuilder.Entity<Qualification>(c =>
			{
				c.ToTable("Qualification");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.Difficulty).IsRequired();
				c.Property(d => d.Name).IsRequired();
				c.Property(d => d.SourceCourseId).IsRequired();
				//todo setup foreign keys
			});
			modelBuilder.Entity<QualifiedCandidates>(c =>
			{
				c.ToTable("QualifiedCandidates");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CandidateId).IsRequired();
				c.Property(d => d.OpeningId).IsRequired();
				//todo setup foreign keys
			});
			modelBuilder.Entity<Session>(c =>
			{
				c.ToTable("QualifiedCandidates");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
				c.Property(d => d.CourseId).IsRequired();
				c.Property(d => d.DateTimeEnd).IsRequired();
				c.Property(d => d.DateTimeStart).IsRequired();
				c.Property(d => d.LocationId).IsRequired();
				c.Property(d => d.Price).IsRequired();
				//todo setup foreign keys
			});







		}
	}
}
