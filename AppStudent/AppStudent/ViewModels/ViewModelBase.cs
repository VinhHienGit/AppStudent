﻿using AppStudent.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppStudent.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        protected IApplicationCommands ApplicationCommands { get; private set; }

        protected IApplicationDatas ApplicationDatas { get; private set; }
        public ViewModelBase(INavigationService navigationService, IApplicationCommands applicationCommands, IApplicationDatas applicationDatas)
        {
            NavigationService = navigationService;
            ApplicationCommands = applicationCommands;
            ApplicationDatas = applicationDatas;
        }
        public ViewModelBase(INavigationService navigationService)
        { 
            NavigationService = navigationService;
        }
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
