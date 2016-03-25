using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExmpleAppp.DownloadModule.Services
{
    public class DownloadService : IVkAudioDownloadService
    {
        WebClient client;

        public DownloadService()
        {
            client = new WebClient();
        }

        public Task DownloadAsync(Uri Url, string FileName, string Path)
        {
            await client.DownloadFileAsync(Url,FileName);
        }
    }
}
