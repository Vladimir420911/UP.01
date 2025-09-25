using System;
using ClassLib;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TOrderService
    {
        [TestMethod]
        public void CreateOrder_ValidData_ReturnsOrder()
        {
            var service = new OrderService();
            int tableId = 5;
            var items = new List<OrderItem>
            {
                new OrderItem { MenuItemId = 1, Name = "Паста Карбонара", Price = 580.00m, Quantity = 2 },
                new OrderItem { MenuItemId = 2, Name = "Сок", Price = 300.00m, Quantity = 1 }
            };

            var order = service.CreateOrder(tableId, items);

            Assert.IsNotNull(order);
            Assert.AreEqual(tableId, order.TableId);
            Assert.AreEqual(2, order.Items.Count);
            Assert.AreEqual(1460.00m, order.TotalAmount); // 580*2 + 300*1
            Assert.AreEqual(true, order.InWork);
        }

        [TestMethod]
        public void CreateOrder_NoTableSelected_ThrowsException()
        {
            var service = new OrderService();
            int tableId = 0; // неверный номер столика
            var items = new List<OrderItem>
            {
                new OrderItem { MenuItemId = 1, Name = "Паста Карбонара", Price = 580.00m, Quantity = 1 }
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.CreateOrder(tableId, items));
            Assert.AreEqual("Номер столика не выбран.", ex.Message);
        }

        [TestMethod]
        public void CreateOrder_NoItemsSelected_ThrowsException()
        {
            var service = new OrderService();
            int tableId = 5;
            List<OrderItem> items = null;

            var ex = Assert.ThrowsException<ArgumentException>(() => service.CreateOrder(tableId, items));
            Assert.AreEqual("Не выбрано ни одного блюда.", ex.Message);
        }
    }
}
