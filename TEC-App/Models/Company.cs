using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsIncludedInList { get; set; }

		public ICollection<Opening> Openings { get; set; }
		public JobHistory JobHistory { get; set; } 
	}
}