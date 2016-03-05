using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;

namespace ExmpleApp.Infrastructure
{
    //Класс для создания одного экземпляра vkapi
    public sealed class VKSingle
    {
        static readonly VkApi instance = new VkApi();

        static VKSingle() { }

        VKSingle(){ }

        public static VkApi Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
