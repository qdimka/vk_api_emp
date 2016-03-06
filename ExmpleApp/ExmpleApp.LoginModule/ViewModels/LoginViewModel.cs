using ExmpleApp.LoginModule.Models;
using ExmpleApp.LoginModule.Services;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.LoginModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewModel : BindableBase
    {
        private readonly IloginService loginService;
        private LoginModel login;

        [ImportingConstructor]
        public LoginViewModel(IloginService LoginService)
        {
            this.loginService = LoginService;
        }

        public LoginModel Login
        {
            get { return this.login; }
            set { this.SetProperty(ref this.login, value); }
        }

    }
}
