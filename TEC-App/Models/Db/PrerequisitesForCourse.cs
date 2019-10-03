namespace TEC_App.Models.Db
{
	public class PrerequisitesForCourse
	{
		public int Id { get; set; }


		public int QualificationId { get; set; }
		public Qualification Qualification { get; set; }


		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}