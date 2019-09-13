using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Models;

namespace TEC_App.Helpers
{
	public class TecAppContext : DbContext
	{
		#region Properties
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<JobHistory> JobHistories { get; set; }
		public DbSet<Opening> Openings { get; set; }
		public DbSet<Placement> Placements { get; set; }
		public DbSet<Qualification> Qualifications { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<PrerequisitesForCourse> PrerequisitesForCourses { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Candidate_Qualification> CandidateQualifications { get; set; }
		public DbSet<Candidate_Session> Candidate_Session_Pairs { get; set; }
		#endregion

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

				c.HasMany(d => d.Address_Location_Pairs)
					.WithOne(d => d.Address)
					.HasForeignKey(d => d.AddressId);

				c.HasMany(d => d.Address_Candidate_Pairs)
					.WithOne(d => d.Address)
					.HasForeignKey(d => d.AddressId);
			});
			modelBuilder.Entity<Address_Candidate>(c => {
				c.ToTable("Address_Candidate");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Address_Location>(c => {
				c.ToTable("Address_Location");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Candidate>(c => {
				c.ToTable("Candidate");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Candidate_Qualification>(c => {
				c.ToTable("Candidate_Qualification");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Candidate_Session>(c => {
				c.ToTable("Candidate_Session");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Company>(c => {
				c.ToTable("Company");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Course>(c => {
				c.ToTable("Course");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Job>(c => {
				c.ToTable("Job");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<JobHistory>(c => {
				c.ToTable("JobHistory");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<JobHistory_Company>(c => {
				c.ToTable("JobHistory_Company");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<JobHistory_Job>(c => {
				c.ToTable("JobHistory_Job");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Location>(c => {
				c.ToTable("Location");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Opening>(c => {
				c.ToTable("Opening");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Placement>(c => {
				c.ToTable("Placement");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<PrerequisitesForCourse>(c => {
				c.ToTable("PrerequisitesForCourse");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Qualification>(c => {
				c.ToTable("Qualification");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Session>(c => {
				c.ToTable("Session");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Session_Location>(c => {
				c.ToTable("Session_Location");
				c.HasKey(d => d.Id);
				c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			});
			//modelBuilder.Entity<Address>(c =>
			//	{
			//		c.ToTable("Address");
			//		c.HasKey(d => d.Id);
			//		c.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
			//		c.HasOne(d => d.Candidate)
			//			.WithOne(d => d.Address)
			//			.HasForeignKey<Candidate>(d=>d.AddressId);


			//		c.HasOne(d => d.Location)
			//			.WithOne(d => d.Address)
			//			.HasForeignKey<Location>(d=>d.AddressId);
			//	}
			//);

		}
	}
}
