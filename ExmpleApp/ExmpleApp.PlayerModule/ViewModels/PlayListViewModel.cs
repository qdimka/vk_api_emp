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
    public class PlayListViewModel : BindableBase
    {
        IVkAudioServiceAsync audioService;
        IVkApi api;
        ObservableCollection<Audio> music;
        private string query;


        [ImportingConstructor]
        public PlayListViewModel(IVkAudioServiceAsync audioService, IVkApi api)
        {
            this.api = api;
            this.audioService = audioService;

            GetUserMusicAsync();
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
                this.OnPropertyChanged(() => SearchQuery);
            }
        }

        public DelegateCommand GetPopularMusic => DelegateCommand.FromAsyncHandler(GetPopularAsync);

        public DelegateCommand GetRecommendMusic => DelegateCommand.FromAsyncHandler(GetRecommendAsync);

        public DelegateCommand GetSearchMusic => DelegateCommand.FromAsyncHandler(GetSearchAsync);

        public DelegateCommand GetMusicByUser => DelegateCommand.FromAsyncHandler(GetUserMusicAsync);

        private async Task GetPopularAsync()
        {
            Music = await this.audioService.GetPopularMusicAsync();
        }

        private async Task GetRecommendAsync()
        {
            Music = await this.audioService.GetRecommendMusicAsync();
        }

        private async Task GetSearchAsync()
        {
            Music = await this.audioService.GetSearchMusicResultsAsync(SearchQuery);
        }

        private async Task GetUserMusicAsync()
        {
            Music = await this.audioService.GetMusicByUserIdAsync(api.Instance.UserId);
        }
    }
}
