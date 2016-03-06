using ExmpleApp.Views;
using Prism.Mef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Prism.Modularity;

namespace ExmpleApp
{
    public class Bootstrapper : MefBootstrapper
    {
        private const string ModuleCatalogUri = "/ExmpleApp;component/ModulesCatalog.xaml";

        //Создание загрузчика для приложения
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        //Инициализация
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        //Обязательно переопределить для использования Mef
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ExmpleApp.LoginModule.LoginModule).Assembly));
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
