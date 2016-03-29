using ExmpleApp.Infrastructure.SharedServices;
using ExmpleApp.PlayerModule.Helpers;
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

namespace ExmpleApp.PlayerModule.ViewModels
{
    public class PlayListViewModel:BindableBase
    {
        private IVkAudioServiceAsync audioService;
        private IMediaPlayer player;
        private IVkApi api;
        private IFileDialog filePath;
        private IVkAudioDownloadService download;

        private ICommand playCommand;

        #region Private

        private ObservableCollection<Audio> playList;
        private string query;
        private Audio selectedAudio;

        #endregion

        public PlayListViewModel(IVkAudioServiceAsync audioService,
                                 IMediaPlayer mediaPlayer,
                                 IVkApi api,
                                 IFileDialog filePath,
                                 IVkAudioDownloadService download)
        {
            this.audioService = audioService;
            this.api = api;
            this.player = mediaPlayer;
            this.download = download;
            this.filePath = filePath;


            Task.Run(() => GetUserMusicAsync()).Wait();
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

        public Audio SelectedAudio
        {
            get
            {
                return this.selectedAudio ?? PlayList.First();
            }
            set
            {
                this.SetProperty(ref this.selectedAudio, value);
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

        public DelegateCommand DownloadMusic => DelegateCommand.FromAsyncHandler(Download);

        public ICommand PlayCommand => this.playCommand ?? (this.playCommand = new DelegateCommand(Play, () => this.selectedAudio != null));

        #endregion

        #region Service

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

        private async Task Download()
        {
            try
            {
                string path = filePath.GetSavePath();
                if (path == null) return;
                await download.DownloadAsync((new Uri(GetNoHttpsUrl.Get(SelectedAudio.Url.ToString()))), $"{SelectedAudio.Artist} - {SelectedAudio.Title}.mp3", path);
            }
            catch(Exception ex)
            {

            }
        }


        #endregion

        #region Methods

        private void Play()
        {
            var audio = SelectedAudio;

            if (audio == null)
                return;

            player.Play(audio);
        }

        public Audio Next(Audio audio)
        {
            int oldIndex;

            if (PlayList == null && audio == null)
            {
                return null;
            }
            else
            {
                oldIndex = PlayList.IndexOf(audio);
            }

            if (oldIndex + 1 >= PlayList.Count) return PlayList.First();

            return audio = PlayList.ElementAt(oldIndex + 1);
        }

        public Audio Prev(Audio audio)
        {
            int oldIndex;

            if (PlayList == null && audio == null)
            {
                return null;
            }
            else
            {
                oldIndex = PlayList.IndexOf(audio);
            }

            if (oldIndex - 1 <= 0) return PlayList.ElementAt(PlayList.Count - 1);

            return audio = PlayList.ElementAt(oldIndex - 1);
        }

        #endregion

    }
}
