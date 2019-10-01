using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TEC_App.ViewModels
{
	public class CourseViewDTO
	{
		public string CourseName { get; set; }
		public string Location { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
	}

	public class CourseView_ViewModel : ViewModelBase
	{
		public ObservableCollection<CourseViewDTO> CourseViewDtos { get; set; } =
			new ObservableCollection<CourseViewDTO>();
	}
}
