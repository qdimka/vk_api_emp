using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExmpleApp.Infrastructure.Models;
using ExmpleApp.Infrastructure.SharedServices;
using VkNet.Enums.Filters;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IloginService))]
    public class LoginService : IloginService
    {
        private ulong AppID = 1111111;
        IVkApi api;

        [ImportingConstructor]
        public LoginService(IVkApi Api)
        {
            this.api = Api;
        }


        public void Login(LoginModel user)
        {
            if (user == null)
                return;

            try
            {
                api.Instance.Authorize(new VkNet.ApiAuthParams() {
                    ApplicationId = AppID,
                    Login = user.Email,
                    Password = user.Password,
                    Settings = Settings.All });
            }
            catch
            {

            }

        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
