using Prism.Mef.Modularity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.VKApiModule
{
    [ModuleExport(typeof(VKApiModule))]
    public class VKApiModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
