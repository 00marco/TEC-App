using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Qualification
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Difficulty { get; set; }


		public int SourceCourseId { get; set; }
		public Course Course { get; set; }

		public int OpeningId { get; set; }
		public Opening Opening { get; set; }


		public ICollection<CandidateQualification> CandidatesQualifications { get; set; }
		public ICollection<PrerequisitesForCourse> PrerequisitesForCourse { get; set; }
	}
}