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
		//****
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
	}
}
