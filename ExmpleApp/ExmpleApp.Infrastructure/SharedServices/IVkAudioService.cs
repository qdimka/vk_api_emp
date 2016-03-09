//using ExmpleApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;

namespace ExmpleApp.Infrastructure.SharedServices
{
    public interface IVkAudioService
    {
        ReadOnlyCollection<Audio> GetMusicByUserId(long? userId);

        ReadOnlyCollection<Audio> GetPopularMusic();

        ReadOnlyCollection<Audio> GetRecommendMusic();

        ReadOnlyCollection<Audio> GetSearchMusicResults(string SearchQuery);
    }
}
