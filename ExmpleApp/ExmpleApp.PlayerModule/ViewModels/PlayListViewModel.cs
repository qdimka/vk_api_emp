using ExmpleApp.Infrastructure.SharedServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayListViewModel:BindableBase
    {
        IVkAudioService _audioService;
        IVkApi api;
        List<Audio> music;
        private string query;

        private readonly DelegateCommand getPopular;
        private readonly DelegateCommand getRecommend;
        private readonly DelegateCommand getSearch;
        private readonly DelegateCommand getUserMusic;

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioService audioService, IVkApi api)
        {
            this.api = api;
            this._audioService = audioService;
            music = this._audioService.GetMusicByUserId(api.Instance.UserId);

            this.getPopular = new DelegateCommand(GetPopular);
            this.getRecommend = new DelegateCommand(GetRecommend);
            this.getSearch = new DelegateCommand(GetSearch);
            this.getUserMusic = new DelegateCommand(GetUserMusic);
        }


        List<Audio> Music
        {
            get { return this.music; }
            set
            {
                this.SetProperty(ref this.music, value);
            }
        }

        public String SearchQuery
        {
            get { return this.query; }
            set
            {
                this.SetProperty(ref this.query, value);
            }
        }

        public ICommand GetPopularMusic => getPopular;

        public ICommand GetRecommendMusic => getRecommend;

        public ICommand GetSearchMusic => getSearch;

        public ICommand GetMusicByUser => getUserMusic;

        private void GetPopular()
        {
            music = this._audioService.GetPopularMusic();
            int i = music.Count;
        }

        private void GetRecommend()
        {
            music = this._audioService.GetPopularMusic();
        }

        private void GetSearch()
        {
            music = this._audioService.GetPopularMusic();
        }

        private void GetUserMusic()
        {
            Music = this._audioService.GetPopularMusic();
        }
    }
}
