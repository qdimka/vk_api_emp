using ExmpleApp.LoginModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.LoginModule.Services
{
    public interface IloginService
    {
        void Login(LoginModel user);
        void LogOut();
    }
}
