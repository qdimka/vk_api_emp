using ExmpleApp.PlayerModule.Helpers;
using ExmpleApp.PlayerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.Core
{
    [Export(typeof(IMediaPlayer))]
    public class MediaPlayerInstance : IMediaPlayer
    {
        private Audio currentAudio;

        private MediaPlayer player;

        public Audio CurrentPlay
        {
            get { return currentAudio; }
            set { currentAudio = value; }
        }

        public bool IsPause => player.CanPause;

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

        public void Play(Audio obj)
        {
            player.Open((new Uri(GetNoHttpsUrl.Get(obj.Url.ToString()), UriKind.Absolute)));
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
