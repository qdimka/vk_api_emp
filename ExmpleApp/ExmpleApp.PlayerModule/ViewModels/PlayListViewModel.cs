using ExmpleApp.Infrastructure.SharedServices;
using ExmpleApp.PlayerModule.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class PlayListViewModel : BindableBase
    {
        private IEventAggregator eventAggregator;
        private IVkAudioServiceAsync audioService;
        private IVkApi api;

        private ObservableCollection<Audio> music;
        private string query;

        [ImportingConstructor]
        public PlayListViewModel(IVkAudioServiceAsync audioService,
                                 IVkApi api,
                                 IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.api = api;
            this.audioService = audioService;
            Task.Run(() => GetUserMusicAsync());

            SelectItem = new DelegateCommand<Audio>(OnItemSelected);
        }

        public ObservableCollection<Audio> Music
        {
            get { return this.music; }
            set
            {
                this.SetProperty(ref this.music, value);
                this.OnPropertyChanged(() => Music);
            }
        }

        public String SearchQuery
        {
            get { return this.query; }
            set
            {
                this.SetProperty(ref this.query, value);
                this.OnPropertyChanged(() => SearchQuery);
            }
        }


        public DelegateCommand GetPopularMusic => DelegateCommand.FromAsyncHandler(GetPopularAsync);

        public DelegateCommand GetRecommendMusic => DelegateCommand.FromAsyncHandler(GetRecommendAsync);

        public DelegateCommand GetSearchMusic => DelegateCommand.FromAsyncHandler(GetSearchAsync);

        public DelegateCommand GetMusicByUser => DelegateCommand.FromAsyncHandler(GetUserMusicAsync);

        private async Task GetPopularAsync()
        {
            Music = await this.audioService.GetPopularMusicAsync();
        }

        private async Task GetRecommendAsync()
        {
            Music = await this.audioService.GetRecommendMusicAsync();
        }

        private async Task GetSearchAsync()
        {
            Music = await this.audioService.GetSearchMusicResultsAsync(SearchQuery);
        }

        private async Task GetUserMusicAsync()
        {
            Music = await this.audioService.GetMusicByUserIdAsync(api.Instance.UserId);
        }


        //Выбранное в listview
        private Audio selectedAudio;

        public Audio SelectedAudio
        {
            get { return this.selectedAudio; }
            set
            {
                this.SetProperty(ref this.selectedAudio, value);
                this.OnPropertyChanged(()=>SelectedAudio);
            }
        }

        public ICommand SelectItem { get; set; }

        private void OnItemSelected(Audio obj)
        {
            if (obj == null)
                return;

            SelectedAudio = obj;

            eventAggregator.GetEvent<SelectedItemEvent>().Publish(obj);
        }

    }
}
