using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.Interfaces
{
    public interface IMediaPlayer
    {
        Audio CurrentPlay { get; set; }

        double Volume { get; set; }

        TimeSpan Position { get; }

        bool CanPause { get; }

        void Play(Audio obj);

        void Stop();

        void Pause();

        void AudioEnd(EventHandler handler);
    }
}
