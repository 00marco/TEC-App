using System;
using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsIncludedInList { get; set; }
		public DateTime Timestamp { get; set; }

		public ICollection<Opening> Openings { get; set; }
		public ICollection<JobHistory_Company> JobHistory_Company_Pairs { get; set; }

	}
}