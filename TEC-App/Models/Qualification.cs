namespace TEC_App.Models
{
	public class Qualification
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Difficulty { get; set; }
		public int SourceCourseId { get; set; }
	}
}