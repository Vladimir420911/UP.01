using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLib
{
    public class OrderManager : IOrderRepository
    {
        private string _connectionString = "server=localhost;user=root;database=restarauntdb;password=1234567890;port=3306;";

        public string AddOrder(Order order)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // Начало транзакции
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Вставка основного заказа
                        string orderQuery = @"
                            INSERT INTO Orders (SeatId, TotalPrice, StatusId) 
                            VALUES (@SeatId, @TotalPrice, @StatusId);
                            SELECT LAST_INSERT_ID();";

                        int orderId;
                        using (var cmd = new MySqlCommand(orderQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@SeatId", order.SeatId);
                            cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                            cmd.Parameters.AddWithValue("@StatusId", (int)order.Status + 1); // +1 т.к. в БД StatusId начинается с 1

                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Вставка элементов заказа
                        string itemsQuery = @"
                            INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, Price) 
                            VALUES (@OrderId, @MenuItemId, @Quantity, @Price)";

                        foreach (var item in order.Items)
                        {
                            using (var cmd = new MySqlCommand(itemsQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", orderId);
                                cmd.Parameters.AddWithValue("@MenuItemId", item.Key.ID_);
                                cmd.Parameters.AddWithValue("@Quantity", item.Value);
                                cmd.Parameters.AddWithValue("@Price", item.Key.Price);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return "Заказ принят";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Ошибка при создании заказа: {ex.Message}";
                    }
                }
            }
        }

        public Order CreateOrder(int seatId, Dictionary<OrderItem, int> items)
        {
            if (seatId <= 0 || items == null || items.Count == 0)
                return null;

            // Рассчитываем общую стоимость
            decimal totalPrice = items.Sum(item => item.Key.Price * item.Value);

            var order = new Order
            {
                OrderId = 0, // Будет установлен при сохранении в БД
                SeatId = seatId,
                Items = items,
                TotalPrice = totalPrice,
                Status = OrderStatus.Accepted
            };

            return order;
        }

        public string UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Orders SET StatusId = @StatusId WHERE OrderId = @OrderId";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StatusId", (int)newStatus + 1); // +1 т.к. в БД StatusId начинается с 1
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0 ? "Статус изменен" : "Заказ не найден";
                }
            }
        }

        public void AddNewOrderItem(string name, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Заполните все обязательные поля");

            if (price <= 0)
                throw new ArgumentException("Цена должна быть положительным числом");

            // Проверка дубликата названия
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM MenuItems WHERE Name = @Name";

                using (var checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Name", name);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                        throw new InvalidOperationException("Блюдо с таким названием уже существует в меню");
                }

                // Добавление нового блюда
                string insertQuery = @"
                    INSERT INTO MenuItems (Name, Price, Description) 
                    VALUES (@Name, @Price, @Description)";

                using (var insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@Name", name);
                    insertCmd.Parameters.AddWithValue("@Price", price);
                    insertCmd.Parameters.AddWithValue("@Description", description ?? "");

                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        // В OrderManager.cs - изменить метод EditOrderItem
        public void EditOrderItem(OrderItem item, string newName, decimal newPrice, string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newName) || newPrice <= 0m)
                throw new ArgumentException("Некорректные данные");

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            UPDATE MenuItems 
            SET Name = @Name, Price = @Price, Description = @Description 
            WHERE MenuItemId = @MenuItemId";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@Price", newPrice);
                    cmd.Parameters.AddWithValue("@Description", newDescription ?? "");
                    cmd.Parameters.AddWithValue("@MenuItemId", item.ID_);

                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                        throw new InvalidOperationException("Блюдо не найдено");
                }
            }
        }

        public BindingList<OrderItem> GetMenu()
        {
            var menu = new BindingList<OrderItem>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT MenuItemId, Name, Price, Description FROM MenuItems WHERE IsActive = TRUE";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menu.Add(new OrderItem(
                            reader.GetInt32("MenuItemId"),
                            reader.GetString("Name"),
                            reader.GetDecimal("Price"),
                            reader.GetString("Description")
                        ));
                    }
                }
            }

            return menu;
        }

        public OrderItem GetItemById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT MenuItemId, Name, Price, Description FROM MenuItems WHERE MenuItemId = @MenuItemId";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MenuItemId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderItem(
                                reader.GetInt32("MenuItemId"),
                                reader.GetString("Name"),
                                reader.GetDecimal("Price"),
                                reader.GetString("Description")
                            );
                        }
                    }
                }
            }
            return null;
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT o.OrderId, o.SeatId, o.TotalPrice, s.StatusName 
                    FROM Orders o 
                    INNER JOIN OrderStatuses s ON o.StatusId = s.StatusId";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order
                        {
                            OrderId = reader.GetInt32("OrderId"),
                            SeatId = reader.GetInt32("SeatId"),
                            TotalPrice = reader.GetDecimal("TotalPrice"),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader.GetString("StatusName")),
                            Items = new Dictionary<OrderItem, int>()
                        };

                        // Загружаем элементы заказа
                        order.Items = GetOrderItems(order.OrderId);
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        private Dictionary<OrderItem, int> GetOrderItems(int orderId)
        {
            var items = new Dictionary<OrderItem, int>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT oi.MenuItemId, oi.Quantity, oi.Price, m.Name, m.Description 
                    FROM OrderItems oi 
                    INNER JOIN MenuItems m ON oi.MenuItemId = m.MenuItemId 
                    WHERE oi.OrderId = @OrderId";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new OrderItem(
                                reader.GetInt32("MenuItemId"),
                                reader.GetString("Name"),
                                reader.GetDecimal("Price"),
                                reader.GetString("Description")
                            );

                            items.Add(item, reader.GetInt32("Quantity"));
                        }
                    }
                }
            }

            return items;
        }

        public List<Order> GetOrdersByStatus(OrderStatus status)
        {
            var orders = new List<Order>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT o.OrderId, o.SeatId, o.TotalPrice 
                    FROM Orders o 
                    INNER JOIN OrderStatuses s ON o.StatusId = s.StatusId 
                    WHERE s.StatusName = @StatusName";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StatusName", status.ToString());

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                OrderId = reader.GetInt32("OrderId"),
                                SeatId = reader.GetInt32("SeatId"),
                                TotalPrice = reader.GetDecimal("TotalPrice"),
                                Status = status,
                                Items = GetOrderItems(reader.GetInt32("OrderId"))
                            };

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }
    }
}
