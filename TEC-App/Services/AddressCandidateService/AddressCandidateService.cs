using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressCandidateService
{
    public class AddressCandidateService : IAddressCandidateService
    {
        public readonly TecAppContext context;

        public AddressCandidateService(TecAppContext context)
        {
            this.context = context;
        }

        public Address_Candidate AddAddressToCandidate(Address_Candidate addressCandidate)
        {
            context.Address_Candidate_Pairs.Add(addressCandidate);
            context.SaveChanges();
            return addressCandidate;
        }

        public void RemoveAddressFromCandidate(int addressId, int candidateId)
        {
            context.Remove(context.Address_Candidate_Pairs.Single(d => d.AddressId == addressId && d.CandidateId == candidateId));
            context.SaveChanges();
        }

        public void Soft_RemoveAddressFromCandidate(int addressId, int candidateId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Address_Candidate addressCandidate)
        {
            context.Remove(context.Address_Candidate_Pairs.Single(d => d.Id == addressCandidate.Id));
            context.SaveChanges();
        }

        public List<Address_Candidate> GetAllAddressCandidatePairs()
        {
            var addressCandidatePairs = context.Set<Address_Candidate>()
                .Include(d => d.Candidate)
                .Include(d => d.Address)
                .ToList();
            return addressCandidatePairs;
        }

        public Address_Candidate GetPairFromAddressAndCandidateId(int addressId, int candidateId)
        {
            var ret = GetAllAddressCandidatePairs().FirstOrDefault(d => d.AddressId == addressId && d.CandidateId == candidateId);
            if (ret == null)
            {
                return new Address_Candidate()
                {
                    Id=-1
                };
            }

            return ret;
        }
    }
}
