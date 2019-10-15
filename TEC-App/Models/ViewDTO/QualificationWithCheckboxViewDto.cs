using TEC_App.Models.Db;

namespace TEC_App.Models.ViewDTO
{
    public class QualificationWithCheckboxViewDto
    {
        public Qualification Qualification { get; set; }
        public bool IsSelected { get; set; }
    }
}
