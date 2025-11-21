using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class AuthManager : IStaffRepository
    {
        public Staff CurrentUser { get; private set; }
        private BindingList<Staff> users = new BindingList<Staff>();

        public Staff GetUserByLogin(string login)
        {
            foreach(var user in users)
            {
                if(user.Login == login)
                {
                    return user;
                }
            }

            return null;
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

        public RegistrationResult Register(string username, string login, string password, UserRole role)
        {
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return RegistrationResult.EmptyFields;
            }

            if(users.Any(u => u.Login == login))
            {
                return RegistrationResult.ExistingLogin;
            }

            if(users.Any(u => u.UserName == username))
            {
                return RegistrationResult.ExistingUsername;
            }

            var newStaff = new Staff(users.Count+1, password);
            newStaff.Login = login;
            newStaff.UserName = username;
            newStaff.Role = role;

            users.Add(newStaff);
            return RegistrationResult.Success;
        }

        public BindingList<Staff> GetAllUsers()
        {
            return users;
        }
    }
}
