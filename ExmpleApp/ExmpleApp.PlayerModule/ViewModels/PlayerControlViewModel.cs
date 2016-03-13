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
        #endregion

        [ImportingConstructor]
        public PlayerControlViewModel(IMediaPlayer mediaPlayer,
                                      IEventAggregator eventAggregator)
        {
            this.mediaPlayer = mediaPlayer;
            this.eventAggregator = eventAggregator;

            SelectedItemEvent audioSelected = eventAggregator.GetEvent<SelectedItemEvent>();
            subscriptionToken = audioSelected.Subscribe((audio) => CurrentAudio = audio, ThreadOption.UIThread, false, (audio) => true);
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

        public ICommand PlayPauseCommand => this.playPauseCommand ?? (this.playPauseCommand = new DelegateCommand(PlayPause,()=>CurrentAudio!=null));
        public ICommand PrevAudioCommand => this.prevAudioCommand ?? (this.prevAudioCommand = new DelegateCommand(ToPrevAudio));
        public ICommand NextAudioCommand => this.nextAudioCommand ?? (this.nextAudioCommand = new DelegateCommand(ToNextAuido));
        public ICommand StopCommand => this.stopCommand ?? (this.stopCommand = new DelegateCommand(Stop));

        #endregion

        #region Methods

        private void PlayPause()
        {
            mediaPlayer.Instance.Open(new Uri(GetNoHttpsUrl.Get(this.CurrentAudio.Url.ToString()), UriKind.Absolute));
            mediaPlayer.Instance.Play();
        }

        private void ToPrevAudio()
        {
            throw new NotImplementedException();
        }

        private void ToNextAuido()
        {
            throw new NotImplementedException();
        }

        private void Stop()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
