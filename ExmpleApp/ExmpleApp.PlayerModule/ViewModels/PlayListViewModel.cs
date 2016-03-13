using ExmpleApp.Infrastructure.SharedServices;
using ExmpleApp.PlayerModule.Interfaces;
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
using ExmpleApp.PlayerModule.Helpers;
using Prism.Events;
using ExmpleApp.PlayerModule.Core;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayListViewModel : BindableBase
    {
        #region Interfaces

        private IEventAggregator eventAggregator;
        private IVkAudioServiceAsync audioService;
        private IMediaPlayer mediaPlayer;
        private ICommand selectItem;
        private ICommand playCommand;
        private IVkApi api;

        #endregion

        #region Private

        private ObservableCollection<Audio> playList;
        private Audio selectedAudio;
        private string query;

        #endregion

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioServiceAsync audioService,
                                 IMediaPlayer mediaPlayer,
                                 IEventAggregator eventAggregator,
                                 IVkApi api)
        {
            this.audioService = audioService;
            this.mediaPlayer = mediaPlayer;
            this.eventAggregator = eventAggregator;
            this.api = api;

            Task.Run(() => GetPopularAsync());
        }

        #region Properties

        public ObservableCollection<Audio> PlayList
        {
            get { return this.playList; }
            set
            {
                this.SetProperty(ref this.playList, value);
            }
        }

        public Audio CurrentPlayAudio
        {
            get { return this.selectedAudio; }
            set
            {
                this.SetProperty(ref this.selectedAudio, value);
                eventAggregator.GetEvent<SelectedItemEvent>().Publish(this.selectedAudio);
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
        #endregion

        #region Commands

        public DelegateCommand GetPopularMusic => DelegateCommand.FromAsyncHandler(GetPopularAsync);

        public DelegateCommand GetRecommendMusic => DelegateCommand.FromAsyncHandler(GetRecommendAsync);

        public DelegateCommand GetSearchMusic => DelegateCommand.FromAsyncHandler(GetSearchAsync);

        public DelegateCommand GetMusicByUser => DelegateCommand.FromAsyncHandler(GetUserMusicAsync);

        public ICommand SelectItem => this.selectItem ?? (this.selectItem = new DelegateCommand<Audio>(OnItemSelected));

        public ICommand PlayCommand => this.playCommand ?? (this.playCommand = new DelegateCommand(Play,()=>this.selectedAudio!=null));

        #endregion

        #region Methods

        private async Task GetPopularAsync()
        {
            PlayList = await this.audioService.GetPopularMusicAsync();
        }

        private async Task GetRecommendAsync()
        {
            PlayList = await this.audioService.GetRecommendMusicAsync();
        }

        private async Task GetSearchAsync()
        {
            PlayList = await this.audioService.GetSearchMusicResultsAsync(SearchQuery);
        }

        private async Task GetUserMusicAsync()
        {
            PlayList = await this.audioService.GetMusicByUserIdAsync(api.Instance.UserId);
        }


        private void OnItemSelected(Audio obj)
        {
            if (obj == null)
                return;

            this.selectedAudio = obj;
        }

        private void Play()
        {
            CurrentPlayAudio = this.selectedAudio;
            mediaPlayer.Instance.Open(new Uri(GetNoHttpsUrl.Get(this.CurrentPlayAudio.Url.ToString()), UriKind.Absolute));
            mediaPlayer.Instance.Play();
        }

        public Audio PrevAudio()
        {
            int oldIndex;

            if (PlayList == null && selectedAudio == null)
            {
                return null;
            }
            else
            {
                oldIndex = PlayList.IndexOf(selectedAudio);
            }

            if (oldIndex - 1 <= 0) return PlayList.ElementAt(PlayList.Count - 1);

            return PlayList.ElementAt(oldIndex - 1);
        }

        public Audio GetNextAudio()
        {
            int oldIndex;

            if (PlayList == null && selectedAudio == null)
            {
                return null;
            }
            else
            {
                oldIndex = PlayList.IndexOf(selectedAudio);
            }

            if (oldIndex + 1 > PlayList.Count) return PlayList.First();

            return PlayList.ElementAt(oldIndex + 1);
        }

        #endregion


    }
}
