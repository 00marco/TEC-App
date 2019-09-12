using System.Collections;
using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int QualificationId { get; set; }
		public Qualification Qualification { get; set; }


		public ICollection<PrerequisitesForCourse> PrerequisitesForCourse { get; set; }
		public ICollection<Session> Sessions { get; set; }
	}

}