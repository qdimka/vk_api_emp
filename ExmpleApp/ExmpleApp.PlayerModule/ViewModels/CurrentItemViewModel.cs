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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrentItemViewModel:BindableBase
    {
        private IMediaElement player;
        private IEventAggregator eventAggregator;

        private readonly DelegateCommand play;
        private readonly DelegateCommand prev;
        private readonly DelegateCommand next;
        private readonly DelegateCommand stop;
        MediaPlayer pl = new MediaPlayer();
        private Audio currentAudio;
        private SubscriptionToken subscriptionToken;

        [ImportingConstructor]
        public CurrentItemViewModel(IMediaElement player,
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
            }
        }

        public MediaElement Media => player.Instance;

        public ICommand PlayCommand => play;
        public ICommand PrevCommand => prev;
        public ICommand NextCommand => next;
        public ICommand StopCommand => stop;

        private void Play()
        {
            Media.Source = new Uri(NoHttps(CurrentAudio.Url.ToString()), UriKind.Absolute);
            Media.Play();
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

        public string NoHttps(string uri)
        {
            string temp = uri;

            if(uri.Contains("https"))
            {
                temp = uri.Remove(uri.IndexOf('s'), 1);
            }

            return temp.Substring(0, uri.IndexOf('?')-1);
        }
    }
}
