using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExmpleApp.Infrastructure.Models;
using ExmpleApp.Infrastructure.SharedServices;

namespace ExmpleApp.VKApiModule.Services
{
    [Export(typeof(IloginService))]
    public class LoginService : IloginService
    {

        IVkApi api;

        [ImportingConstructor]
        public LoginService(IVkApi Api)
        {
            this.api = Api;
        }


        public void Login(LoginModel user)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
