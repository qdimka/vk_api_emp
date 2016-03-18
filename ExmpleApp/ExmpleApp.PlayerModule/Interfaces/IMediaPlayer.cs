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

        bool IsPause { get; }

        void Play(Audio obj);

        void Stop();

        void AudioEnd(EventHandler handler);
    }
}
