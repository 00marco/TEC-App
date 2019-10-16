using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            OldCandidate = obj.Candidate;
            NewCandidate = DeepCopyForCandidate(OldCandidate);
            InitializeAddresses();
            InitializeQualifications();
        }

        public void InitializeQualifications()
        {
            var candidateQualifications =
                CandidateQualificationService.GetAll().Where(c => c.CandidateId == OldCandidate.Id);


            Qualifications.Clear();
            foreach (var v in QualificationsService.GetAllAndMapToQualificationWithCheckBoxDto())
            {
                if (candidateQualifications.Any(d =>
                    d.CandidateId == OldCandidate.Id && d.QualificationId == v.Qualification.Id))
                {
                    v.IsSelected = true;
                }
                else
                {
                    v.IsSelected = false;
                }
                Qualifications.Add(v);
            }
        }

        public void InitializeAddresses()
        {
           
            var addressCandidates = OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList();
            int counter = 0;
            foreach (var v in addressCandidates)
            {
                if(counter == 0) OldAddress1 = v.Address;
                if(counter == 1) OldAddress2 = v.Address;
                if(counter == 2) OldAddress3 = v.Address;

                counter++;
            }
            NewAddress1 = DeepCopyForAddress(OldAddress1);
            NewAddress2 = DeepCopyForAddress(OldAddress2);
            NewAddress3 = DeepCopyForAddress(OldAddress3);
        }

        private Address DeepCopyForAddress(Address address)
        {
            return new Address()
            {
                ZipCode = address.ZipCode,
                City = address.City,
                Province = address.Province,
                Street = address.Street
            };
        }

        private Candidate DeepCopyForCandidate(Candidate oldCandidate)
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
        public Address NewAddress1 { get; set; }
        public Address NewAddress2 { get; set; }
        public Address NewAddress3 { get; set; }
        public Address OldAddress1 { get; set; }
        public Address OldAddress2 { get; set; }
        public Address OldAddress3 { get; set; }

        public ICommand UpdateCommand => new RelayCommand(UpdateProc);

        private void UpdateProc()
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //TODO add message
                //update candidate name only
                var newCandidate = OldCandidate;
                OldCandidate = CandidateService.UpdateCandidate(OldCandidate, NewCandidate);

                //update candidate qualifications
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

                //update candidate addresses
                UpdateCandidateAddresses();
            }
            BackProc();
        }

        private void UpdateCandidateAddresses()
        {
            ////if string changed - add new, remove old
            ////if string empty - remove old
            if (NewAddress1.FullAddress != OldAddress1.FullAddress)
            {
                if (!(string.IsNullOrEmpty(NewAddress1.City) && string.IsNullOrEmpty(NewAddress1.ZipCode) && string.IsNullOrEmpty(NewAddress1.Street) && string.IsNullOrEmpty(NewAddress1.Province)))
                {
                    NewAddress1 = AddressService.AddAddress(NewAddress1);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = NewAddress1,
                        Candidate = NewCandidate
                    });
                }
                //remove old address
                AddressCandidateService.RemoveAddressFromCandidate(OldAddress1.Id, NewCandidate.Id);
            }

            if (NewAddress2.FullAddress != OldAddress2.FullAddress)
            {
                if (!(string.IsNullOrEmpty(NewAddress2.City) && string.IsNullOrEmpty(NewAddress2.ZipCode) && string.IsNullOrEmpty(NewAddress2.Street) && string.IsNullOrEmpty(NewAddress2.Province)))
                {
                    NewAddress2 = AddressService.AddAddress(NewAddress2);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = NewAddress2,
                        Candidate = NewCandidate
                    });
                }

                //remove old address
                AddressCandidateService.RemoveAddressFromCandidate(OldAddress2.Id, NewCandidate.Id);
            }
            if (NewAddress3.FullAddress != OldAddress3.FullAddress)
            {
                if (!(string.IsNullOrEmpty(NewAddress3.City) && string.IsNullOrEmpty(NewAddress3.ZipCode) && string.IsNullOrEmpty(NewAddress3.Street) && string.IsNullOrEmpty(NewAddress3.Province)))
                {
                    NewAddress3 = AddressService.AddAddress(NewAddress3);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = NewAddress3,
                        Candidate = NewCandidate
                    });
                }

                //remove old address
                AddressCandidateService.RemoveAddressFromCandidate(OldAddress3.Id, NewCandidate.Id);
            }
            //if (Address2 != OldAddress2)
            //{
            //    var newAddress = AddressService.AddAddress(new Address()
            //    {
            //        ZipCode = Address2
            //        //TODO make way to parse Address object from strings
            //    });

            //    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
            //    {
            //        Address = newAddress,
            //        Candidate = NewCandidate
            //    });
            //    //remove old address
            //    AddressCandidateService.RemoveAddressFromCandidate(OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[1].AddressId, OldCandidate.Id);
            //}

            //if (Address3 != OldAddress3)
            //{
            //    var newAddress = AddressService.AddAddress(new Address()
            //    {
            //        ZipCode = Address3
            //        //TODO make way to parse Address object from strings
            //    });

            //    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
            //    {
            //        Address = newAddress,
            //        Candidate = NewCandidate
            //    });

            //    //remove old address
            //    AddressCandidateService.RemoveAddressFromCandidate(OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[2].AddressId, OldCandidate.Id);
            //}



            //if (string.IsNullOrEmpty(Address1))
            //{
            //    //remove old address
            //    AddressCandidateService.RemoveAddressFromCandidate(OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[0].AddressId, OldCandidate.Id);
            //}

            //if (string.IsNullOrEmpty(Address2))
            //{
            //    //remove old address
            //    AddressCandidateService.RemoveAddressFromCandidate(OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[1].AddressId, OldCandidate.Id);
            //}

            //if (string.IsNullOrEmpty(Address3))
            //{
            //    //remove old address
            //    AddressCandidateService.RemoveAddressFromCandidate(OldCandidate.Addresses.Where(d => d.CandidateId == OldCandidate.Id).ToList()[2].AddressId, OldCandidate.Id);
            //}
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CandidateView_ViewModel)));
            Messenger.Default.Send(new LoadCandidateViewMessage());
        }
        //private void AddAddresses()
        //{
        //    if (!string.IsNullOrEmpty(Address1))
        //    {
        //        var newAddress = AddressService.AddAddress(new Address()
        //        {
        //            ZipCode = Address1
        //            //TODO make way to parse Address object from strings
        //        });

        //        AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
        //        {
        //            Address = newAddress,
        //            Candidate = OldCandidate
        //        });
        //    }

        //    if (!string.IsNullOrEmpty(Address2))
        //    {
        //        var newAddress = AddressService.AddAddress(new Address()
        //        {
        //            ZipCode = Address2
        //            //TODO make way to parse Address object from strings
        //        });

        //        AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
        //        {
        //            Address = newAddress,
        //            Candidate = OldCandidate
        //        });
        //    }

        //    if (!string.IsNullOrEmpty(Address3))
        //    {
        //        var newAddress = AddressService.AddAddress(new Address()
        //        {
        //            ZipCode = Address3
        //            //TODO make way to parse Address object from strings
        //        });

        //        AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
        //        {
        //            Address = newAddress,
        //            Candidate = OldCandidate
        //        });
        //    }
        //}

    }
}
