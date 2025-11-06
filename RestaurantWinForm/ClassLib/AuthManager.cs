using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class AuthManager : IStaffRepository
    {
        public Staff CurrentUser { get; private set; }

        public Staff GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public LoginResult Login(string login, string password)
        {
            if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                CurrentUser = null;
                return LoginResult.PasswordOrLoginIsWhiteSpace;
            }

            var staff = GetUserByLogin(login); 
            if(staff == null)
            {
                CurrentUser = null;
                return LoginResult.WrongLogin;
            }

            if (staff != null && staff.Password_ != password)
            {
                CurrentUser = null;
                return LoginResult.WrongPassword;
            }

            CurrentUser = staff;
            return LoginResult.Success;
        }
    }
}
