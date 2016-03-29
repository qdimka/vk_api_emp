using ExmpleApp.Infrastructure.SharedServices;
using ExmpleApp.PlayerModule.Interfaces;
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

        [ImportingConstructor]
        public PlayerViewModel(IVkAudioServiceAsync audioService,
                               IMediaPlayer mediaPlayer,
                               IVkApi api,
                               IFileDialog filePath,
                               IVkAudioDownloadService download)
        {
            this.PlayListViewModel = new PlayListViewModel(audioService, mediaPlayer, api, filePath, download);
            this.PlayerControlViewModel = new PlayerControlViewModel(this, mediaPlayer);
        }

        public PlayListViewModel PlayListViewModel { get; private set; }

        public PlayerControlViewModel PlayerControlViewModel { get; private set; }

    }
}
