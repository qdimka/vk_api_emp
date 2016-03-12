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
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrentItemViewModel:BindableBase
    {
        IMediaPlayer player;

        private readonly DelegateCommand play;
        private readonly DelegateCommand prev;
        private readonly DelegateCommand next;
        private readonly DelegateCommand stop;

        [ImportingConstructor]
        public CurrentItemViewModel(IMediaPlayer player)
        {
            this.player = player;

            this.play = new DelegateCommand(Play);
            this.prev = new DelegateCommand(Prev);
            this.next = new DelegateCommand(Next);
            this.stop = new DelegateCommand(Stop);
        }


        public ICommand PlayCommand => play;
        public ICommand PrevCommand => prev;
        public ICommand NextCommand => next;
        public ICommand StopCommand => stop;

        private void Play()
        {

        }

        private void Prev()
        {

        }

        private void Next()
        {

        }

        private void Stop()
        {

        }
    }
}
