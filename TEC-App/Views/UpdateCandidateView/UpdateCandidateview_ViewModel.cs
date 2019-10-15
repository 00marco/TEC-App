using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.AddressCandidateService;
using TEC_App.Services.AddressService;
using TEC_App.Services.CandidateQualificationService;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.QualificationsService;
using TEC_App.ViewModels;
using TEC_App.Views.CandidateView;

namespace TEC_App.Views.UpdateCandidateView
{
    public class UpdateCandidateview_ViewModel : ViewModelBase
    {
        public UpdateCandidateview_ViewModel(ICandidateService candidateService, ICandidateQualificationService candidateQualificationService, IAddressCandidateService addressCandidateService, IAddressService addressService, IQualificationsService qualificationsService)
        {
            CandidateService = candidateService;
            QualificationsService = qualificationsService;
            CandidateQualificationService = candidateQualificationService;
            AddressCandidateService = addressCandidateService;
            AddressService = addressService;
			Messenger.Default.Register<LoadUpdateCandidateViewMessage>(this, NotifyMe);
        }

        private void NotifyMe(LoadUpdateCandidateViewMessage obj)
        {
            Qualifications.Clear();
            foreach (var v in QualificationsService.GetAllAndMapToQualificationWithCheckBoxDto())
            {
                Qualifications.Add(v);
            }

            OldCandidate = obj.Candidate;
            NewCandidate = DeepCopy(OldCandidate);
            var addressCandidates = OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList();
            Address1 = OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[0].Address.FullAddress;
            Address2 = OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[1].Address.FullAddress;
            Address3 = OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[2].Address.FullAddress;
            
        }

        private Candidate DeepCopy(Candidate oldCandidate)
        {
            return new Candidate()
            {
                Addresses = oldCandidate.Addresses,
                CandidateQualifications = oldCandidate.CandidateQualifications,
                Candidate_Session_Pairs = oldCandidate.Candidate_Session_Pairs,
                JobHistories = oldCandidate.JobHistories,
                Placements = oldCandidate.Placements,
                FirstName = oldCandidate.FirstName,
                MiddleName = oldCandidate.MiddleName,
                LastName = oldCandidate.LastName,
                Timestamp = oldCandidate.Timestamp,
                Id = oldCandidate.Id
            };
        }

        public ICandidateService CandidateService { get; set; }
        public IQualificationsService QualificationsService { get; set; }
        public IAddressService AddressService { get; set; }
        public ICandidateQualificationService CandidateQualificationService { get; set; }
        public IAddressCandidateService AddressCandidateService { get; set; }
        public List<QualificationWithCheckboxViewDto> Qualifications { get; set; } = new List<QualificationWithCheckboxViewDto>();
        public Candidate OldCandidate { get; set; }
        public Candidate NewCandidate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public ICommand UpdateCommand => new RelayCommand(UpdateProc);

        private void UpdateProc()
        {
            //TODO add message
            var newCandidate = OldCandidate;
            OldCandidate = CandidateService.UpdateCandidate(OldCandidate, NewCandidate);
            foreach (var v in Qualifications)
            {
                if (v.IsSelected)
                {
                    CandidateQualificationService.AddQualificationToCandidate(new Candidate_Qualification()
                    {
                        Candidate = OldCandidate,
                        Qualification = v.Qualification
                    });
                }
                else
                {
                    CandidateQualificationService.RemoveQualificationFromCandidate(OldCandidate.Id, v.Qualification.Id);
                }
            }
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CandidateView_ViewModel)));
            Messenger.Default.Send(new LoadCandidateViewMessage());
        }
        private void AddAddresses()
        {
            if (!string.IsNullOrEmpty(Address1))
            {
                var newAddress = AddressService.AddAddress(new Address()
                {
                    ZipCode = Address1
                    //TODO make way to parse Address object from strings
                });

                AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                {
                    Address = newAddress,
                    Candidate = OldCandidate
                });
            }

            if (!string.IsNullOrEmpty(Address2))
            {
                var newAddress = AddressService.AddAddress(new Address()
                {
                    ZipCode = Address2
                    //TODO make way to parse Address object from strings
                });

                AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                {
                    Address = newAddress,
                    Candidate = OldCandidate
                });
            }

            if (!string.IsNullOrEmpty(Address3))
            {
                var newAddress = AddressService.AddAddress(new Address()
                {
                    ZipCode = Address3
                    //TODO make way to parse Address object from strings
                });

                AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                {
                    Address = newAddress,
                    Candidate = OldCandidate
                });
            }
        }

    }
}
