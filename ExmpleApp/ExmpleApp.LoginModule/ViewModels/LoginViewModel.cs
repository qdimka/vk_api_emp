using ExmpleApp.LoginModule.Models;
using ExmpleApp.LoginModule.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExmpleApp.LoginModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewModel : BindableBase
    {
        private readonly DelegateCommand loginCommand;
        private readonly IloginService loginService;
        private LoginModel login;

        [ImportingConstructor]
        public LoginViewModel(IloginService LoginService)
        {
            this.login = new LoginModel();
            this.loginService = LoginService;
            this.loginCommand = new DelegateCommand(LogIn);
        }

        public LoginModel Login
        {
            get { return this.login; }
            set { this.SetProperty(ref this.login, value); }
        }

        public ICommand LoginCommand
        {
            get { return loginCommand; }
        }

        private void LogIn()
        {
            loginService.Login(Login);
        }
    }
}
