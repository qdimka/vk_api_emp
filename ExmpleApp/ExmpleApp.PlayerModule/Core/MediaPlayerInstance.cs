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
    [Export(typeof(IMediaPlayer))]
    public class MediaPlayerInstance : BindableBase, IMediaPlayer
    {
        private Audio currentAudio;

        private MediaPlayer player;

        public MediaPlayerInstance()
        {
            player = new MediaPlayer();
        }


        public Audio CurrentPlay
        {
            get { return currentAudio; }
            set
            {
                currentAudio = value;
                this.OnPropertyChanged(() => CurrentPlay);
            }
        }

        public bool CanPause => player.CanPause;

        public TimeSpan Position => player.Position;

        public double Volume
        {
            get { return player.Volume; }
            set { player.Volume = value; }
        }

        public void AudioEnd(EventHandler handler)
        {
            player.MediaEnded += handler;
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Play(Audio obj)
        {
            CurrentPlay = obj;
            player.Open((new Uri(GetNoHttpsUrl.Get(CurrentPlay.Url.ToString()), UriKind.Absolute)));
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
