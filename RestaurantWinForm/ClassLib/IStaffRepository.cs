using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public interface IStaffRepository
    {
        LoginResult Login(string login, string password);
        Staff GetUserByLogin(string login);
        RegistrationResult Register(string username, string login, string password, UserRole role);
        BindingList<Staff> GetAllUsers();
    }
}
