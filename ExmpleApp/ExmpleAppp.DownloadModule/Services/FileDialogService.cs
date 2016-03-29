using System;
using System.Windows.Forms;
using ExmpleApp.Infrastructure.SharedServices;

namespace ExmpleApp.DownloadModule.Services
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
