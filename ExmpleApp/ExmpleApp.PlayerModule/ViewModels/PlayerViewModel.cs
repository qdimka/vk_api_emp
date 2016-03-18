using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            this.PlayListViewModel = new PlayListViewModel();
            this.PlayerControlViewModel = new PlayerControlViewModel(this);
            this.MediaViewModel = new MediaViewModel();
        }

        public PlayListViewModel PlayListViewModel { get; private set; }

        public PlayerControlViewModel PlayerControlViewModel { get; private set; }

        public MediaViewModel MediaViewModel { get; private set; }

    }
}
