using ExmpleApp.PlayerModule.Core;
using ExmpleApp.PlayerModule.Helpers;
using ExmpleApp.PlayerModule.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
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
    public class PlayerControlViewModel : BindableBase
    {
        #region Interfaces

        private IEventAggregator eventAggregator;
        private IMediaPlayer mediaPlayer;

        #endregion

        #region Private

        private ICommand playPauseCommand;
        private ICommand prevAudioCommand;
        private ICommand nextAudioCommand;
        private ICommand stopCommand;

        private Audio currentAudio;
        private SubscriptionToken subscriptionToken;
        private PlayListViewModel playListViewModel;
        #endregion

        [ImportingConstructor]
        public PlayerControlViewModel(IMediaPlayer mediaPlayer,
                                      IEventAggregator eventAggregator,
                                      PlayListViewModel playListViewModel)
        {
            this.mediaPlayer = mediaPlayer;
            this.eventAggregator = eventAggregator;

            //Нужно найти другой способ связать viewmodel
            this.playListViewModel = playListViewModel;

            SelectedItemEvent audioSelected = eventAggregator.GetEvent<SelectedItemEvent>();
            subscriptionToken = audioSelected.Subscribe((audio) => CurrentAudio = audio, ThreadOption.UIThread, false, (audio) => true);

            this.mediaPlayer.Instance.MediaEnded += (s,e) => { this.ToNextAudio(); };
        }

        #region Properties

        public Audio CurrentAudio
        {
            get { return this.currentAudio; }
            set
            {
                this.SetProperty(ref this.currentAudio, value);
            }
        }

        #endregion

        #region Commands

        public ICommand PlayPauseCommand => this.playPauseCommand ?? (this.playPauseCommand = new DelegateCommand(PlayPause));
        public ICommand PrevAudioCommand => this.prevAudioCommand ?? (this.prevAudioCommand = new DelegateCommand(ToPrevAudio));
        public ICommand NextAudioCommand => this.nextAudioCommand ?? (this.nextAudioCommand = new DelegateCommand(ToNextAudio));
        public ICommand StopCommand => this.stopCommand ?? (this.stopCommand = new DelegateCommand(Stop));

        #endregion

        #region Methods

        private void PlayPause()
        {
            var audio = playListViewModel.SelectedAudio;
            if (audio != null)
            {
                CurrentAudio = audio;

                mediaPlayer.Instance.Open(new Uri(GetNoHttpsUrl.Get(audio.Url.ToString()), UriKind.Absolute));
                mediaPlayer.Instance.Play();
            }
        }

        private void ToPrevAudio()
        {
            var audio = playListViewModel.GetPrevAudio(CurrentAudio);
            if (audio != null)
            {
                CurrentAudio = audio;

                mediaPlayer.Instance.Open(new Uri(GetNoHttpsUrl.Get(audio.Url.ToString()), UriKind.Absolute));
                mediaPlayer.Instance.Play();
            }
        }

        private void ToNextAudio()
        {
            var audio = playListViewModel.GetNextAudio(CurrentAudio);
            if (audio != null)
            {
                CurrentAudio = audio;

                mediaPlayer.Instance.Open(new Uri(GetNoHttpsUrl.Get(audio.Url.ToString()), UriKind.Absolute));
                mediaPlayer.Instance.Play();
            }
        }

        private void Stop()
        {
            mediaPlayer.Instance.Stop();
        }

        #endregion
    }
}
