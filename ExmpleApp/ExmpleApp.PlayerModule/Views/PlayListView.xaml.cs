using ExmpleApp.PlayerModule.ViewModels;
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

namespace ExmpleApp.PlayerModule.Views
{
    /// <summary>
    /// Логика взаимодействия для PlayListView.xaml
    /// </summary>
    [Export(typeof(PlayListView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PlayListView : UserControl
    {
        public PlayListView()
        {
            InitializeComponent();
        }

        [Import]
        public PlayListViewModel ViewModel
        {
            get { return this.DataContext as PlayListViewModel; }
            set { this.DataContext = value; }
        }
    }
}
