using System;

namespace TEC_App.Models.DTO
{
	public class CourseWithLocationDTO
	{
		public string CourseName { get; set; }
		public string Location { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
	}
}