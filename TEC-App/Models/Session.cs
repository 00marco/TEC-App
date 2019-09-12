using System;
using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Session
	{
		public Session()
		{

		}
		public int Id { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float Price { get; set; }
		public int NumberOfAttendees { get; set; }


		public int CourseId { get; set; }
		public Course Course { get; set; }


		public ICollection<Candidate_Session> Candidate_Session_Pairs { get; set; }
		public ICollection<Session_Location> Session_Location_Pairs { get; set; }
	}
}