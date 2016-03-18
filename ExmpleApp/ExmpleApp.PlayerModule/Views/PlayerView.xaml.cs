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
    /// Логика взаимодействия для PlayerView.xaml
    /// </summary>
    [Export(typeof(PlayerView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        [Import]
        public PlayerViewModel ViewModel
        {
            get { return this.DataContext as PlayerViewModel; }
            set { this.DataContext = value; }
        }
    }
}
