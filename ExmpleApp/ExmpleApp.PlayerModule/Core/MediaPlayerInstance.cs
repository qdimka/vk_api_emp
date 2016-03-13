using ExmpleApp.PlayerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace ExmpleApp.PlayerModule.Core
{
    [Export(typeof(IMediaPlayer))]
    public class MediaElementInstance : IMediaPlayer
    {
        private readonly MediaPlayer instance;

        public MediaElementInstance()
        {
            instance = new MediaPlayer();
            //instance.LoadedBehavior = MediaState.Manual;
        }

        public MediaPlayer Instance => instance;

    }
}
