using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Staff
    {
        private int StaffId;
        public string Login { get; set; }
        private string Password;
        public string UserName { get; set; }
        public UserRole Role { get; set; }
    }
}
