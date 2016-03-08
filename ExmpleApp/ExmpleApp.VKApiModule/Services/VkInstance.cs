using ExmpleApp.Infrastructure.SharedServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IVkApi))]
    public class VkInstance : IVkApi
    {
        private readonly VkApi _api;

        public VkInstance()
        {
            _api = new VkApi();
        }

        public VkApi Instance
        {
            get
            {
                return _api;
            }
        }
    }
}
