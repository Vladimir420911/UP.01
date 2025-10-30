using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Staff
    {
        private int StaffId;
        public string Login { get; set; }
        private string Password;
        public string Password_ { get { return Password; } }
        public string Username { get; set; }
        public UserRole Role { get; set; }

        public Staff(int id, string password)
        {
            StaffId = id;
            Password = password;
        }
    }
}
