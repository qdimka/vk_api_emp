using ExmpleApp.Infrastructure;
using ExmpleApp.PlayerModule.Views;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.PlayerModule
{
    [ModuleExport(typeof(PlayerModule))]
    public class PlayerModule : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(PlayListView));

            this.regionManager.RegisterViewWithRegion(RegionNames.PlayerRegion, typeof(PlayerControlView));
        }
    }
}
