using System;

namespace TEC_App.Models
{
	public class Session
	{
		public Session()
		{

		}
		public int Id { get; set; }
		public int CourseId { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float Price { get; set; }
		public int LocationId { get; set; }

	}
}