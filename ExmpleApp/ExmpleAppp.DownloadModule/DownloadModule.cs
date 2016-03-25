using Prism.Mef.Modularity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.DownloadModule
{
    [ModuleExport(typeof(DownloadModule))]
    public class DownloadModule : IModule
    {
        public void Initialize()
        {
            
        }
    }
}
