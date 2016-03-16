using ExmpleApp.Infrastructure.SharedServices;
using ExmpleApp.PlayerModule.Interfaces;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class PlayerViewModel:BindableBase
    {

        [ImportingConstructor]
        public PlayerViewModel(IVkAudioServiceAsync audioService,
                               IMediaElement mediaPlayer,
                               IEventAggregator eventAggregator,
                               IVkApi api)
        {
            this.PlayListViewModel = new PlayListViewModel(audioService, mediaPlayer, eventAggregator, api);
        }

        public PlayListViewModel PlayListViewModel { get; private set; }
    }
}
