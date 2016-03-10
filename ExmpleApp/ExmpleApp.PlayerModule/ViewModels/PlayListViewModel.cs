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
        IVkAudioService audioService;
        IVkApi api;
        ObservableCollection<Audio> music;
        private string query;

        private readonly DelegateCommand getPopular;
        private readonly DelegateCommand getRecommend;
        private readonly DelegateCommand getSearch;
        private readonly DelegateCommand getUserMusic;

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioService audioService, IVkApi api)
        {
            this.api = api;
            this.audioService = audioService;

            music = this.audioService.GetMusicByUserId(api.Instance.UserId);

            this.getPopular = new DelegateCommand(GetPopular);
            this.getRecommend = new DelegateCommand(GetRecommend);
            this.getSearch = new DelegateCommand(GetSearch);
            this.getUserMusic = new DelegateCommand(GetUserMusic);
        }


        public ObservableCollection<Audio> Music
        {
            get { return this.music; }
            set
            {
                this.SetProperty(ref this.music, value);
                this.OnPropertyChanged(() => Music);
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
            Music = this.audioService.GetPopularMusic();
        }

        private void GetRecommend()
        {
            Music = this.audioService.GetPopularMusic();
        }

        private void GetSearch()
        {
            Music = this.audioService.GetPopularMusic();
        }

        private void GetUserMusic()
        {
            Music = this.audioService.GetPopularMusic();
        }
    }
}
