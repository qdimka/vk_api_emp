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

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IVkAudioService))]
    public class AudioService : IVkAudioService
    {
        IVkApi _api;

        [ImportingConstructor]
        public AudioService(IVkApi api)
        {
            this._api = api;
        }

        public List<Audio> GetMusicByUserId(long? userId)
        {
            try
            {
                return _api.Instance?.Audio.Get((long)userId).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Audio> GetPopularMusic()
        {
            return _api.Instance?.Audio.GetPopular().ToList();
        }

        public List<Audio> GetRecommendMusic()
        {
            return _api.Instance?.Audio.GetPopular().ToList();
        }

        public List<Audio> GetSearchMusicResults(string SearchQuery)
        {
            long total = 0;

            AudioSearchParams @params = new AudioSearchParams()
            {
                Autocomplete = true,
                Offset = 1000,
                Query = SearchQuery,
                Sort = AudioSort.Duration
            };
            return _api.Instance?.Audio.Search(@params,out total).ToList();
        }
    }
}
