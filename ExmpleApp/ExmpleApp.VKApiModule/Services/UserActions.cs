using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IUserActions))]
    public class UserActions : IUserActions
    {
        IVkApi api;

        [ImportingConstructor]
        public UserActions(IVkApi api)
        {
            this.api = api;
        }

        public void AddMusic(Audio audio)
        {
            if (audio == null) return;

            api.Instance.Audio.Add((long)audio.Id, (long)audio.OwnerId);
        }

        public Uri GetUserPhoto()
        {
            var p = api.Instance.Users.Get((long)api.Instance.UserId);
            return p.PhotoMaxOrig;
        }

        public void RemoveMusic(Audio audio)
        {
            if (audio == null) return;

            api.Instance.Audio.Delete((long)audio.Id, (long)api.Instance.UserId);
        }
    }
}
