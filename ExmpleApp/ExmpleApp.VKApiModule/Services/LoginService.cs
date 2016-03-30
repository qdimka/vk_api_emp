using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExmpleApp.Infrastructure.Models;
using ExmpleApp.Infrastructure.SharedServices;
using VkNet.Enums.Filters;
using VkNet.Exception;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IloginService))]
    public class LoginService : IloginService
    {
        private ulong AppID = 5342182;
        IVkApi api;

        [ImportingConstructor]
        public LoginService(IVkApi Api)
        {
            this.api = Api;
        }


        public bool Login(LoginModel user)
        {
            if (user == null)
                return false;

            try
            {
                api.Instance.Authorize(new VkNet.ApiAuthParams()
                {
                    ApplicationId = AppID,
                    Login = user.Email,
                    Password = user.Password,
                    Settings = Settings.All
                });
            }
            catch (VkApiAuthorizationException)
            {

            }
            catch (VkApiException)
            {
                
            }

            return api.Instance.AccessToken != null;

        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
