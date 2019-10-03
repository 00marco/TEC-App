using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TEC_App.Models.DTO;

namespace TEC_App.ViewModels
{
	public class CourseView_ViewModel : ViewModelBase
	{
		public ObservableCollection<CourseWithLocationDTO> CourseViewDtos { get; set; } =
			new ObservableCollection<CourseWithLocationDTO>();
	}
}
