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
        static readonly VkApi instance = new VkApi();

        public VkApi Instance()
        {
            return instance;
        }
    }
}
