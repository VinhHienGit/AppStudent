﻿using AppStudent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStudent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentManagementPage : MasterDetailPage
    {
        public ListView ListView;
        public StudentManagementPage()
        {
            InitializeComponent();
        }
        
    }
}