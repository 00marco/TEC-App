using System.Linq;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Views.CandidateView;

namespace TEC_App.Services.CandidateService.QueryObjects
{
    public static class CandidateWithCheckBoxDtoSelect
    {
        public static IQueryable<CandidateWithCheckBoxDTO> MapCandidateToCandidateWithCheckBoxDto(this IQueryable<Candidate> candidates)
        {
            return candidates.Select(candidate => new CandidateWithCheckBoxDTO()
            {
                Candidate = candidate
            });
        }
    }
}