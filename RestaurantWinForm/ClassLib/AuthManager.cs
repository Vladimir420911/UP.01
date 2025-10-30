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

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                CurrentUser = null;
                return false;
            }

            var staff = _staffRepository.GetByUsername(username);
            if (staff == null || staff.Password_ != password)
            {
                CurrentUser = null;
                return false;
            }

            CurrentUser = staff;
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
