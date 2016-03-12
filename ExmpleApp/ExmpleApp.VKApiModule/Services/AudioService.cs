using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Enums;
using VkNet.Model;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IVkAudioServiceAsync))]
    public class AudioService : IVkAudioServiceAsync
    {
        IVkApi api;

        [ImportingConstructor]
        public AudioService(IVkApi api)
        {
            this.api = api;
        }


        public Task<ObservableCollection<Audio>> GetMusicByUserIdAsync(long? userId)
        {
            User user;
            return Task.Run(() =>
            {
                var audios = api.Instance?.Audio.Get(out user, new AudioGetParams() { OwnerId = userId });
                return new ObservableCollection<Audio>(audios.Select(a => a));
            });
        }

        public Task<ObservableCollection<Audio>> GetPopularMusicAsync()
        {
            return Task.Run(() =>
            {
                var audios = api.Instance?.Audio.GetPopular();
                return new ObservableCollection<Audio>(audios.Select(a => a));
            });
        }

        public Task<ObservableCollection<Audio>> GetRecommendMusicAsync()
        {
            return Task.Run(() =>
            {
                var audios = api.Instance?.Audio.GetRecommendations();
                return new ObservableCollection<Audio>(audios.Select(a => a));
            });
        }

        public Task<ObservableCollection<Audio>> GetSearchMusicResultsAsync(string SearchQuery)
        {
            long total = 0;

            AudioSearchParams @params = new AudioSearchParams()
            {
                Autocomplete = true,
                Query = SearchQuery,
                Sort = AudioSort.Duration
            };

            return Task.Run(() =>
            {
                var audios = api.Instance?.Audio.Search(@params, out total);
                return new ObservableCollection<Audio>(audios.Select(a => a));
            });
        }
    }
}
