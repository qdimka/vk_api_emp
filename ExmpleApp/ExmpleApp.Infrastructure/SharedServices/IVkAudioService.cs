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
        List<Audio> GetMusicByUserId(long? userId);

        List<Audio> GetPopularMusic();

        List<Audio> GetRecommendMusic();

        List<Audio> GetSearchMusicResults(string SearchQuery);
    }
}
