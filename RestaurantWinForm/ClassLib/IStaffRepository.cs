using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public interface IStaffRepository
    {
        LoginResult Login(string login, string password);
        Staff GetUserByLogin(string login);
    }
}
