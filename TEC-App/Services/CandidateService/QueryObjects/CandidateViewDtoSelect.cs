using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Views.CandidateView;

namespace TEC_App.Services.CandidateService.QueryObjects
{
    public static class CandidateViewDtoSelect
    {
        public static IQueryable<CandidateViewDTO> MapCandidateToDto(this IQueryable<Candidate> candidates)
        {
            return candidates.Select(candidate => new CandidateViewDTO()
            {
                Candidate = candidate
            });
        }
    }
}
