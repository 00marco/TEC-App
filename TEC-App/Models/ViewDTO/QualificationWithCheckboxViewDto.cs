using TEC_App.Models.Db;

namespace TEC_App.Models.ViewDTO
{
    public class QualificationWithCheckboxViewDto
    {
        public QualificationWithCheckboxViewDto()
        {
            Qualification = new Qualification();
        }
        public Qualification Qualification { get; set; }
        public bool IsSelected { get; set; }
    }
}
