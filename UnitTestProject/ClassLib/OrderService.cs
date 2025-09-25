using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderService
    {
        public Order CreateOrder(int tableId, List<OrderItem> items)
        {
            if (tableId <= 0)
                throw new ArgumentException("Номер столика не выбран.");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Не выбрано ни одного блюда.");

            var order = new Order
            {
                TableId = tableId,
                Items = items,
                TotalAmount = items.Sum(i => i.Price * i.Quantity)
            };

            // Здесь логика сохранения в БД и отправки на кухню
            // SendToKitchen(order);

            return order;
        }
    }
}
