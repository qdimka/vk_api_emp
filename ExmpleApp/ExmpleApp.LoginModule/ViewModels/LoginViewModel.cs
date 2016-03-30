using ExmpleApp.Infrastructure;
using ExmpleApp.Infrastructure.Models;
using ExmpleApp.Infrastructure.SharedServices;
using Prism.Commands;
using Prism.Modularity;
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
        private readonly IRegionManager regionManager;

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        //Вью на которую переходим при успешной авторизации
        private const string playListView = "PlayerView";

        private Uri PlayListViewUrl = new Uri(playListView, UriKind.Relative);
        private LoginModel login;

        [ImportingConstructor]
        public LoginViewModel(IloginService LoginService,IRegionManager regionManager)
        {
            this.login = new LoginModel();
            this.loginService = LoginService;
            this.loginCommand = new DelegateCommand(LogIn);
            this.regionManager = regionManager;
        }

        public LoginModel Login
        {
            get { return this.login; }
            set
            {
                this.SetProperty(ref this.login, value);
                this.OnPropertyChanged(()=>Login);
            }
        }

        public ICommand LoginCommand => loginCommand;

        private void LogIn()
        {
            if (!loginService.Login(Login)) return;
            
            this.ModuleManager.LoadModule("PlayerModule");
            this.regionManager.RequestNavigate(RegionNames.MainRegion, PlayListViewUrl);
        }
    }
}
