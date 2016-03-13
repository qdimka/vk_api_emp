using ExmpleApp.PlayerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExmpleApp.PlayerModule.Core
{
    [Export(typeof(IMediaElement))]
    public class MediaElementInstance:IMediaElement
    {
        private readonly MediaElement instance;

        public MediaElementInstance()
        {
            instance = new MediaElement();
            instance.LoadedBehavior = MediaState.Manual;
        }

        public MediaElement Instance => instance;
    }
}
