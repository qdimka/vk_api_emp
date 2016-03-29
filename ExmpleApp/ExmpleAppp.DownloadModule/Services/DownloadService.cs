using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExmpleAppp.DownloadModule.Services
{
    [Export(typeof(IVkAudioDownloadService))]
    public class DownloadService : IVkAudioDownloadService
    {
        WebClient client;

        public DownloadService()
        {
            client = new WebClient();
        }

        public async Task DownloadAsync(Uri Url, string FileName, string Path)
        {
            await client.DownloadFileTaskAsync(Url, $@"{Path}\{FileName}");
        }
    }
}
