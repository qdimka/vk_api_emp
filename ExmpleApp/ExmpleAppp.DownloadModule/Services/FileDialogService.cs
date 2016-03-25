using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ExmpleAppp.DownloadModule.Services
{
    public class FileDialogService : IFileDialog
    {
        private FolderBrowserDialog fbDialog;

        public FileDialogService()
        {
            fbDialog = new FolderBrowserDialog();
        }

        public string SaveDialog() 
                => fbDialog.ShowDialog() == DialogResult.OK ? fbDialog.SelectedPath : Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }
}
