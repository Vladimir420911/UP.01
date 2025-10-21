using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderManager : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string AddOrder(Order order)
        {
            orders.Add(order);
            return "Заказ принят";
        }

        public Order CreateOrder(int seatId, List<OrderItem> items)
        {
            if (seatId <= 0)
                return null;

            if (items == null || items.Count == 0)
                return null;

            var order = new Order
            {
                OrderId = orders.Count + 1,
                SeatId = seatId,
                Items = items,
                TotalPrice = items.Sum(i => i.Price * i.Quantity),
                Status = OrderStatus.Принят
            };

            return order;
        }
    }
}
