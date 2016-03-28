using ExmpleApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExmpleApp.Infrastructure.SharedServices
{
    public interface IloginService
    {
        bool Login(LoginModel user);
        void LogOut();
    }
}
