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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }

        public Staff(int id)
        {
            StaffId = id;
        }
    }
}
