using ExmpleApp.PlayerModule.Core;
using ExmpleApp.PlayerModule.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrentItemViewModel:BindableBase
    {
        private IMediaPlayer player;
        private IEventAggregator eventAggregator;

        private readonly DelegateCommand play;
        private readonly DelegateCommand prev;
        private readonly DelegateCommand next;
        private readonly DelegateCommand stop;

        private Audio currentAudio;
        private SubscriptionToken subscriptionToken;

        [ImportingConstructor]
        public CurrentItemViewModel(IMediaPlayer player,
                                    IEventAggregator eventAggregator)
        {
            this.player = player;
            this.eventAggregator = eventAggregator;

            this.play = new DelegateCommand(Play);
            this.prev = new DelegateCommand(Prev);
            this.next = new DelegateCommand(Next);
            this.stop = new DelegateCommand(Stop);

            SelectedItemEvent audioSelected = eventAggregator.GetEvent<SelectedItemEvent>();
            subscriptionToken = audioSelected.Subscribe(OnChangeSelected, ThreadOption.UIThread, false, (shopOrder) => true);
        }

        private void OnChangeSelected(Audio obj)
        {
            CurrentAudio = obj;
        }


        public Audio CurrentAudio
        {
            get { return this.currentAudio; }
            set
            {
                this.SetProperty(ref this.currentAudio, value);
                this.OnPropertyChanged(() => CurrentAudio);
            }
        }

        public ICommand PlayCommand => play;
        public ICommand PrevCommand => prev;
        public ICommand NextCommand => next;
        public ICommand StopCommand => stop;

        private void Play()
        {
            player.Player.Open(CurrentAudio.Url);
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
