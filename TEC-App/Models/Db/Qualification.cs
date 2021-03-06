﻿using System.Collections.Generic;

namespace TEC_App.Models.Db
{
	public class Qualification
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Code { get; set; }



		public ICollection<Opening> Openings { get; set; }
		public ICollection<Candidate_Qualification> CandidatesQualifications { get; set; }
		public ICollection<QualificationDevelopedByCourse> QualificationsDevelopedByCourse { get; set; }
		public ICollection<PrerequisitesForCourse> PrerequisitesForCourse { get; set; }
	}
}