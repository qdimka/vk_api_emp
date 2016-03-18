using ExmpleApp.PlayerModule.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExmpleApp.PlayerModule.ViewModels
{
    public class PlayerControlViewModel:BindableBase
    {
        [Import]
        private IMediaPlayer player;

        private PlayListViewModel playListViewModel;
        private ICommand playPauseCommand;
        private ICommand prevAudioCommand;
        private ICommand nextAudioCommand;
        private ICommand stopCommand;

        public PlayerControlViewModel(PlayerViewModel playerViewModel)
        {
            this.playListViewModel = playerViewModel.PlayListViewModel;

            Player.AudioEnd((s,e) => this.ToNextAudio());
        }

        #region Properties

        public IMediaPlayer Player
        {
            get { return player; }
            private set { }
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
                Player.Play(audio);
            }
        }

        private void ToPrevAudio()
        {
            var audio = playListViewModel.Prev(Player.CurrentPlay);
            if (audio != null)
            {
                Player.Play(audio);
            }
        }

        private void ToNextAudio()
        {
            var audio = playListViewModel.Next(Player.CurrentPlay);
            if (audio != null)
            {
                Player.Play(audio);
            }
        }

        private void Stop()
        {
            Player.Stop();
        }

        private void Pause()
        {
            Player.Pause();
        }

        #endregion
    }
}
