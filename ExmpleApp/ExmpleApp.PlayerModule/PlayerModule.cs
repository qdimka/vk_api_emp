using Prism.Mef.Modularity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.PlayerModule
{
    [ModuleExport(typeof(PlayerModule))]
    public class PlayerModule : IModule
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
