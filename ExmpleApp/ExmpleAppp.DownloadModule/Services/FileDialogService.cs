using System;
using System.Windows.Forms;
using ExmpleApp.Infrastructure.SharedServices;
using System.ComponentModel.Composition;

namespace ExmpleApp.DownloadModule.Services
{
    [Export(typeof(IFileDialog))]
    public class FileDialogService : IFileDialog
    {
        private FolderBrowserDialog fbDialog;

        public FileDialogService()
        {
            fbDialog = new FolderBrowserDialog();
        }

        public string GetSavePath() 
                => fbDialog.ShowDialog() == DialogResult.OK ? fbDialog.SelectedPath : Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }
}
