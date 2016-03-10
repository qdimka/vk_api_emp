using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ExmpleApp.Infrastructure.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Enums;
using VkNet.Model;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IVkAudioService))]
    public class AudioService : IVkAudioService
    {
        IVkApi api;

        [ImportingConstructor]
        public AudioService(IVkApi api)
        {
            this.api = api;
        }

        public ObservableCollection<Audio> GetMusicByUserId(long? userId)
        {
            User user;
            var audios = api.Instance?.Audio.Get(out user, new AudioGetParams() { OwnerId = userId });
            return new ObservableCollection<Audio>(audios.Select(a => a));
        }

        public ObservableCollection<Audio> GetPopularMusic()
        {
            var audios = api.Instance?.Audio.GetPopular();
            return new ObservableCollection<Audio>(audios.Select(a => a));
        }

        public ObservableCollection<Audio> GetRecommendMusic()
        {
            var audios = api.Instance?.Audio.GetRecommendations();
            return new ObservableCollection<Audio>(audios.Select(a => a));
        }

        public ObservableCollection<Audio> GetSearchMusicResults(string SearchQuery)
        {
            long total = 0;

            AudioSearchParams @params = new AudioSearchParams()
            {
                Autocomplete = true,
                Offset = 1000,
                Query = SearchQuery,
                Sort = AudioSort.Duration
            };
            var audios = api.Instance?.Audio.Search(@params, out total);
            return new ObservableCollection<Audio>(audios.Select(a => a));
        }
    }
}
