﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CompanyService;
using TEC_App.Services.JobService;
using TEC_App.Services.OpeningsService;
using TEC_App.Services.QualificationsService;
using TEC_App.ViewModels;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Views.AddOpeningView
{
    public class AddOpeningViewModel : ViewModelBase
    {
        public AddOpeningViewModel(ICompanyService companyService, IQualificationsService qualificationsService, IOpeningsService openingsService, IJobService jobService)
        {
            JobService = jobService;
            QualificationsService = qualificationsService;
            CompanyService = companyService;
            OpeningsService = openingsService;
            Opening = new Opening()
            {
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Now.AddDays(30)
            };
            Messenger.Default.Register<LoadAddOpeningViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadAddOpeningViewMessage message)
        {
            LoadCompanies();
            LoadQualifications();
            LoadJobs();
        }


        public IJobService JobService { get; set; }
        public ICompanyService CompanyService { get; set; }
        public IOpeningsService OpeningsService { get; set; }
        public IQualificationsService QualificationsService { get; set; }
        public Opening Opening { get; set; } 
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public List<Job> Jobs { get; set; } = new List<Job>();

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(OpeningsView_ViewModel)));
        }
        public ICommand AddOpeningCommand => new RelayCommand(AddOpeningProc);

        private void AddOpeningProc()
        {
            OpeningsService.AddOpening(Opening);
            Opening = new Opening();
            BackProc();
            
        }

        public void LoadJobs()
        {
            var jobs = JobService.GetJobs();
            Jobs.Clear();
            foreach (var v in jobs)
            {
                Jobs.Add(v);
            }
        }

        private void LoadQualifications()
        {
            Qualifications.Clear();
            var qualifications = QualificationsService.GetQualifications();
            foreach (var v in qualifications)
            {
                Qualifications.Add(v);
            }
        }

        public void LoadCompanies()
        {
            Companies.Clear();
            var companies = CompanyService.GetCompanies();
            foreach (var v in companies)
            {
                Companies.Add(v);
            }
        }
    }
}
