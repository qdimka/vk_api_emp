﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.Infrastructure.SharedServices
{
    public interface IVkAudioDownloadService
    {
        Task DownloadAsync(Uri Url,string FileName,string Path);
    }
}
