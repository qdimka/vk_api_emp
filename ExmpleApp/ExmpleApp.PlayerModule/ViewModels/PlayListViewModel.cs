using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayListViewModel
    {
        IVkAudioService _audioService;
        ReadOnlyCollection<Audio> _music;

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioService audioService, IVkApi api)
        {
            this._audioService = audioService;
            _music = this._audioService.GetMusicByUserId(api.Instance.UserId);
        }

        //ObservableCollection<Audio> Music
        //{
        //    get { return }
        //    set { this.SetProperty(ref this.login, value); }
        //}
    }
}
