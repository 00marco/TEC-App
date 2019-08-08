using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Models;

namespace TEC_App.Helpers
{
	class Context : DbContext
	{
		public DbSet<Candidate> Candidate { get; set; }
		public DbSet<Company> Company { get; set; }
		public DbSet<Course> Course { get; set; }
		public DbSet<JobHistory> JobHistory { get; set; }
		public DbSet<Opening> Opening { get; set; }
		public DbSet<Placement> Placement { get; set; }
		public DbSet<Qualification> Qualification { get; set; }
		public DbSet<Session> Session { get; set; }	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=SchoolDB; Trusted_Connection=True;");
		}
	}
}
