using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderManager : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        private BindingList<OrderItem> menu = new BindingList<OrderItem>();

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
                Status = OrderStatus.Accepted
            };

            return order;
        }

        public string UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            foreach (var order in orders)
            {
                if (order.OrderId == orderId)
                {
                  order.Status = newStatus;
                    return "Статус изменен";
                }

            }
            return "Заказ не найден";
        }

        public void AddNewOrderItem(string name, decimal price, string description)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Заполните все обязательные поля");
            }

            // Проверка цены
            if (price <= 0)
            {
                throw new ArgumentException("Цена должна быть положительным числом");
            }

            // Проверка дубликата названия
            if (menu.Any(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Блюдо с таким названием уже существует в меню");
            }

            // Добавление нового блюда
            var newItem = new OrderItem(menu.Count+1, name, price, description);

            menu.Add(newItem);
        }

        public OrderItem EditOrderItem(int id, string newName, decimal newPrice, string newDescription)
        {
            if(string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newDescription) || newPrice <= 0m)
            {
                return null;
            }

            OrderItem editItem;
            foreach(var item in menu)
            {
                if(item.ID_ == id)
                {
                    editItem = item;
                    editItem.Name = newName;
                    editItem.Price = newPrice;
                    editItem.Description = newDescription;
                    menu.Remove(item);
                    return editItem;
                }
            }

            return null;
        }

        public BindingList<OrderItem> GetMenu()
        {
            return menu; // Возвращаем копию для защиты от изменений
        }

        public void AddOrderItemToMenu(OrderItem item)
        {
            menu.Add(item);
        }
    }
}
