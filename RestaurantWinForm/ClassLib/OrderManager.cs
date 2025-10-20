using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderManager : IOrderRepository
    {

        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(int seatId, List<OrderItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
