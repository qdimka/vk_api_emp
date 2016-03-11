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
    public interface IVkAudioServiceAsync
    {
        Task<ObservableCollection<Audio>> GetMusicByUserIdAsync(long? userId);

        Task<ObservableCollection<Audio>> GetPopularMusicAsync();

        Task<ObservableCollection<Audio>> GetRecommendMusicAsync();

        Task<ObservableCollection<Audio>> GetSearchMusicResultsAsync(string SearchQuery);
    }
}
