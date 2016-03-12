using ExmpleApp.PlayerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExmpleApp.PlayerModule.Core
{
    [Export(typeof(IMediaPlayer))]
    public class MediaPlayerInstance : IMediaPlayer
    {
        private readonly MediaPlayer player;

        public MediaPlayerInstance()
        {
            player = new MediaPlayer();
        }

        public MediaPlayer Player => player;
    }
}
