using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class AuthManager
    {
        private readonly IStaffRepository _staffRepository;

        public AuthManager(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public Staff CurrentUser { get; private set; }

        public LoginResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                CurrentUser = null;
                return LoginResult.PasswordOrLoginIsWhiteSpace;
            }

            var staff = _staffRepository.GetByUsername(username);
            if (staff == null)
            {
                CurrentUser = null;
                return LoginResult.WrongLogin;
            }

            if(staff != null && staff.Password_ != password)
            {
                CurrentUser = null;
                return LoginResult.WrongPassword;
            }

            CurrentUser = staff;
            return LoginResult.Success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
