using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.Models
{
	public class Job
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Opening> Openings { get; set; }
		public ICollection<JobHistory_Job> JobHistory_Job_Pairs { get; set; }
	}
}
