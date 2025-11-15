using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public interface IOrderRepository
    {
        Order CreateOrder(int seatId, List<OrderItem> items);
        string AddOrder(Order order);
        RegistrationResult Register(string username, string login, string password, UserRole role);
    }
}
