using System.Collections.Generic;

namespace TEC_App.Models.Db
{
	public class Job
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Opening> Openings { get; set; }
		public ICollection<JobHistory_Job> JobHistory_Job_Pairs { get; set; }
	}
}
