using ExmpleApp.Infrastructure;
using Prism.Modularity;
using Prism.Regions;
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
using MahApps.Metro.Controls;

namespace ExmpleApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : MetroWindow, IPartImportsSatisfiedNotification
    {
        private const string LoginModuleName = "LoginModule";
        private static Uri LoginViewUri = new Uri(@"/LoginView", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
        }

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        //Загрузка модуля по умолчанию в регион
        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    if (e.ModuleInfo.ModuleName == LoginModuleName)
                    {
                        this.RegionManager.RequestNavigate(RegionNames.MainRegion, LoginViewUri);
                    }
                };
            //this.RegionManager.RequestNavigate(RegionNames.MainRegion, LoginViewUri);
        }
    }
}
