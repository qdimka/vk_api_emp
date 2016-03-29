using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;

namespace ExmpleApp.Infrastructure.SharedServices
{
    public interface IUserActions
    {
        void AddMusic(Audio audio);
        void RemoveMusic(Audio audio);
        Uri GetUserPhoto();
    }
}
