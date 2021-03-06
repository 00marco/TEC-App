﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.AddressCandidateService;
using TEC_App.Services.AddressService;
using TEC_App.Services.CandidateQualificationService;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.PlacementService;
using TEC_App.Services.QualificationsService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.CandidateView;

namespace TEC_App.Views.AddCandidateView
{
    public class AddCandidateViewModel : ViewModelBase
    {
        public AddCandidateViewModel(ICandidateService candidateService, IQualificationsService qualificationsService,  IAddressCandidateService addressCandidateService, IAddressService addressService, ICandidateQualificationService candidateQualificationService)
        {
            CandidateService = candidateService;
            QualificationsService = qualificationsService;
            AddressCandidateService = addressCandidateService;
            AddressService = addressService;
            CandidateQualificationService = candidateQualificationService;
            Messenger.Default.Register<LoadAddCandidateViewMessage>(this, NotifyMe);
            Candidate = new Candidate();
        }

        public ICandidateService CandidateService { get; set; }
        public IQualificationsService QualificationsService { get; set; }
        public IAddressCandidateService AddressCandidateService { get; set; }
        public IAddressService AddressService { get; set; }
        public ICandidateQualificationService CandidateQualificationService { get; set; }

        public Candidate Candidate { get; set; }
        public Address Address1 { get; set; }
        public Address Address2 { get; set; }
        public Address Address3 { get; set; }
        public List<QualificationWithCheckboxViewDto> Qualifications { get; set; } = new List<QualificationWithCheckboxViewDto>();



        private void NotifyMe(LoadAddCandidateViewMessage obj)
        {
            Candidate = new Candidate();
            LoadQualifications();
            LoadAddresses();
        }

        private void LoadAddresses()
        {
            Address1 = new Address();
            Address2 = new Address();
            Address3 = new Address();
        }

        public void LoadQualifications()
        {
            Qualifications.Clear();
            foreach (var v in QualificationsService.GetAllAndMapToQualificationWithCheckBoxDto())
            {
                
                Qualifications.Add(v);
            }
        }
        public ICommand BackCommand => new RelayCommand(BackProc);
        private void BackProc()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(CandidateView_ViewModel)));
            Messenger.Default.Send<LoadCandidateViewMessage>(new LoadCandidateViewMessage());
        }

        public ICommand AddCommand => new RelayCommand(AddProc);

        private void AddProc()
        {
            Candidate.Timestamp = DateTime.Now;
            if (MessageBox.Show("Are you sure?","",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Candidate = CandidateService.AddCandidate(Candidate);
            }
            AddAddresses();
            AddQualifications();
            BackProc();
        }

        private void AddQualifications()
        {
            foreach (var v in Qualifications)
            {
                if (v.IsSelected)
                {
                    CandidateQualificationService.AddQualificationToCandidate(new Candidate_Qualification()
                    {
                        Candidate = Candidate,
                        Qualification = v.Qualification
                    });
                }
            }
        }
        private void UpdateCandidateAddresses()
        {
            
           
        }

        private void AddAddresses()
        {
            ////if string changed - add new, remove old
            ////if string empty - remove old
                if (!(string.IsNullOrEmpty(Address1.City) && string.IsNullOrEmpty(Address1.ZipCode) && string.IsNullOrEmpty(Address1.Street) && string.IsNullOrEmpty(Address1.Province)))
                {
                    Address1 = AddressService.AddAddress(Address1);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = Address1,
                        Candidate = Candidate
                    });
                }
                //remove old address
                if (!(string.IsNullOrEmpty(Address2.City) && string.IsNullOrEmpty(Address2.ZipCode) && string.IsNullOrEmpty(Address2.Street) && string.IsNullOrEmpty(Address2.Province)))
                {
                    Address2 = AddressService.AddAddress(Address2);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = Address2,
                        Candidate = Candidate
                    });
                }

                //remove old address
                if (!(string.IsNullOrEmpty(Address3.City) && string.IsNullOrEmpty(Address3.ZipCode) && string.IsNullOrEmpty(Address3.Street) && string.IsNullOrEmpty(Address3.Province)))
                {
                    Address3 = AddressService.AddAddress(Address3);

                    AddressCandidateService.AddAddressToCandidate(new Address_Candidate()
                    {
                        Address = Address3,
                        Candidate = Candidate
                    });
                }

        }
    }
}
