﻿using System;
using GalaSoft.MvvmLight.Ioc;
using TEC_App.Services;
using TEC_App.Services.Interfaces;
using TEC_App.Services.MockServices;
using TEC_App.ViewModels;

namespace TEC_App.Helpers
{
	public class InitializeIoc
	{
		private bool isTestMode = true;
		public InitializeIoc()
		{
			CommonServiceLocator.ServiceLocator.SetLocatorProvider(()=>SimpleIoc.Default);
			if (isTestMode)
			{
				RegisterTestServices();
			}
			else
			{
				RegisterServices();
			}

			RegisterViewModels();
		}

		private void RegisterViewModels()
		{
			SimpleIoc.Default.Register<CandidateView_ViewModel>();
			SimpleIoc.Default.Register<CompaniesView_ViewModel>();
			SimpleIoc.Default.Register<CourseView_ViewModel>();
			SimpleIoc.Default.Register<OpeningsView_ViewModel>();
			SimpleIoc.Default.Register<PlacementsView_ViewModel>();
		}

		private void RegisterServices()
		{
			SimpleIoc.Default.Register<ICompanyService, CompanyService>();
			SimpleIoc.Default.Register<ICourseService, CourseService>();
			SimpleIoc.Default.Register<IEmployeeService, EmployeeService>();
			SimpleIoc.Default.Register<IOpeningsService, OpeningsService>();
		}

		private void RegisterTestServices()
		{
			SimpleIoc.Default.Register<ICompanyService, MockCompanyService>();
			SimpleIoc.Default.Register<ICourseService, MockCourseService>();
			SimpleIoc.Default.Register<IEmployeeService, MockEmployeeService>();
			SimpleIoc.Default.Register<IOpeningsService, MockOpeningsService>();

		}
	}
}