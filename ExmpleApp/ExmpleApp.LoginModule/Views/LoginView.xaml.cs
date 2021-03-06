﻿using ExmpleApp.LoginModule.Interface;
using ExmpleApp.LoginModule.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExmpleApp.LoginModule.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    [Export(typeof(LoginView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        [Import]
        public LoginViewModel ViewModel
        {
            get { return this.DataContext as LoginViewModel;}
            set { this.DataContext = value; }
        }
    }
}
