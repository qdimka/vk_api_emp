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
        ObservableCollection<Audio> GetMusicByUserId(long? userId);

        ObservableCollection<Audio> GetPopularMusic();

        ObservableCollection<Audio> GetRecommendMusic();

        ObservableCollection<Audio> GetSearchMusicResults(string SearchQuery);
    }
}
