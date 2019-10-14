using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.CandidateQualificationService
{
    public interface ICandidateQualificationService
    {
        List<Candidate_Qualification> GetAll();
        Candidate_Qualification Add(Candidate_Qualification candidateQualification);
        Candidate_Qualification GetFromIdPair(int candidateId, int qualificationId);
        void Remove(int candidateId, int qualificationId);

    }
}
