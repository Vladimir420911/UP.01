using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderManager : IOrderRepository
    {
        public List<Order> orders = new List<Order>();
        public List<int> seats = new List<int>();
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order CreateOrder(int seatId, List<OrderItem> items)
        {
            if (seatId <= 0)
                throw new ArgumentException("Номер столика не выбран.");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Не выбрано ни одного блюда.");

            var order = new Order
            {
                OrderId = orders.Count + 1,
                SeatId = seatId,
                Items = items,
                TotalPrice = items.Sum(i => i.Price * i.Quantity),
                Status = "Готовка"
            };

            return order;
        }

        public string AddOrder(Order order)
        {
            orders.Add(order);
            return "Заказ отправлен на кухню";
        }
    }
}
