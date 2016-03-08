using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;

namespace ExmpleApp.Infrastructure.SharedServices
{
    public interface IVkApi
    {
        VkApi Instance();
    }
}
