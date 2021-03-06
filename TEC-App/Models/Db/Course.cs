﻿using System.Collections.Generic;

namespace TEC_App.Models.Db
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<PrerequisitesForCourse> PrerequisitesForCourse { get; set; }
		public ICollection<QualificationDevelopedByCourse> QualificationsDevelopedByCourse { get; set; }
		public ICollection<Session> Sessions { get; set; }
	}

}