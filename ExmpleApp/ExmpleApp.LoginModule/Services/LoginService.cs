using ExmpleApp.LoginModule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.LoginModule.Services
{
    [Export(typeof(IloginService))]
    public class LoginService : IloginService
    {
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
