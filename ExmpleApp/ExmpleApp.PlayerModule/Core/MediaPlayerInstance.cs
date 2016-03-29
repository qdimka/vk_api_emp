using ExmpleApp.PlayerModule.Helpers;
using ExmpleApp.PlayerModule.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.Core
{
    public enum PlayerState
    {
        Play,
        Pause,
        Stop
    }


    [Export(typeof(IMediaPlayer))]
    public class MediaPlayerInstance : BindableBase, IMediaPlayer
    {
        private Audio currentAudio;

        private MediaPlayer player;

        private PlayerState playerState;

        public MediaPlayerInstance()
        {
            player = new MediaPlayer();

            playerState = PlayerState.Stop;
        }


        public Audio CurrentPlay
        {
            get { return currentAudio; }
            set
            {
                currentAudio = value;
                OnPropertyChanged(() => CurrentPlay);
            }
        }

        public bool CanPause => player.CanPause;

        public TimeSpan Position
        {
            get { return player.Position; }
            set
            {
                player.Position = value;
                OnPropertyChanged(() => Position);
            }
        }

        public double Volume
        {
            get { return player.Volume; }
            set { player.Volume = value; }
        }

        public void AudioEnd(EventHandler handler)
        {
            player.MediaEnded += handler;
        }

        public PlayerState State
        {
            get { return playerState; }
            set
            {
                playerState = value;
                OnPropertyChanged(()=>State);
            }
        }

        public void Pause()
        {
            if (State == PlayerState.Play)
            {
                player.Pause();
                State = PlayerState.Pause;
            }
            else if (State == PlayerState.Pause)
            {
                player.Play();
                State = PlayerState.Play;
            }
        }

        public void Play()
        {
            player.Play();
        }

        public void Play(Audio obj)
        {
            CurrentPlay = obj;
            player.Open((new Uri(GetNoHttpsUrl.Get(CurrentPlay.Url.ToString()), UriKind.Absolute)));
            player.Play();
            State = PlayerState.Play;
        }

        public void Stop()
        {
            player.Stop();
            State = PlayerState.Stop;
        }
    }
}
