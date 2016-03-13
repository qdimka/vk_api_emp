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

        #endregion
        
        #region Private

        private ObservableCollection<Audio> playList;

        private Audio selectedAudio;

        #endregion

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioServiceAsync audioService,
                                 IMediaPlayer mediaPlayer,
                                 IEventAggregator eventAggregator)
        {
            this.audioService = audioService;
            this.mediaPlayer = mediaPlayer;
            this.eventAggregator = eventAggregator;

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

        #endregion

        #region Commands

        public DelegateCommand GetPopularMusic => DelegateCommand.FromAsyncHandler(GetPopularAsync);

        public ICommand SelectItem => this.selectItem ?? (this.selectItem = new DelegateCommand<Audio>(OnItemSelected));

        public ICommand PlayCommand => this.playCommand ?? (this.playCommand = new DelegateCommand(Play,()=>this.selectedAudio!=null));

        #endregion

        #region Methods

        private async Task GetPopularAsync()
        {
            PlayList = await this.audioService.GetPopularMusicAsync();
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

        #endregion


    }
}
