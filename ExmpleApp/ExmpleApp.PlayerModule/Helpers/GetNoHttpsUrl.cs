using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.PlayerModule.Helpers
{
    public static class GetNoHttpsUrl
    {
        /// <summary>
        /// Убирает s в https
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string Get(string uri)
        {
            string temp = uri;

            if (uri.Contains("https"))
            {
                temp = uri.Remove(uri.IndexOf('s'), 1);
            }

            return temp.Substring(0, uri.IndexOf('?') - 1);
        }
    }
}
