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
        string UpdateOrderStatus(int orderId, OrderStatus newStatus);
        void AddNewOrderItem(string name, decimal price, string description);
        OrderItem GetItemById(int id);
        OrderItem EditOrderItem(OrderItem item, string newName, decimal newPrice, string newDescription);
    }
}
