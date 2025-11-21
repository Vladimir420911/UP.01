using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TAddNewOrderItem
    {
        [TestMethod]
        public void AddNewOrderItem_ValidData_SuccessfullyAdded()
        {
           
            var orderManager = new OrderManager();
            string name = "Пицца Маргарита";
            decimal price = 800;
            string description = "Классическая пицца с томатным соусом и моцареллой";

          
            orderManager.AddNewOrderItem(name, price, description);

            var menu = orderManager.GetMenu();
            Assert.AreEqual(1, menu.Count);

            var addedItem = menu[0];
            Assert.AreEqual(name, addedItem.Name);
            Assert.AreEqual(price, addedItem.Price);
            Assert.AreEqual(description, addedItem.Description);
        }

        [TestMethod]
        public void AddNewOrderItem_DuplicateName_ThrowsException()
        {
          
            var orderManager = new OrderManager();
            string existingName = "Пицца Маргарита";
            orderManager.AddNewOrderItem(existingName, 800, "Описание");

            
            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
                orderManager.AddNewOrderItem(existingName, 900, "Новое описание"));

            Assert.AreEqual("Блюдо с таким названием уже существует в меню", exception.Message);
            Assert.AreEqual(1, orderManager.GetMenu().Count); // Меню не изменилось
        }

        [TestMethod]
        public void AddNewOrderItem_NegativePrice_ThrowsException()
        {
           
            var orderManager = new OrderManager();
            string name = "Пицца Маргарита";
            decimal negativePrice = -700;

            
            var exception = Assert.ThrowsException<ArgumentException>(() =>
                orderManager.AddNewOrderItem(name, negativePrice, "Описание"));

            Assert.AreEqual("Цена должна быть положительным числом", exception.Message);
            Assert.AreEqual(0, orderManager.GetMenu().Count); // Меню осталось пустым
        }

        [TestMethod]
        public void AddNewOrderItem_ZeroPrice_ThrowsException()
        {
            
            var orderManager = new OrderManager();
            string name = "Пицца Маргарита";
            decimal zeroPrice = 0;

           
            var exception = Assert.ThrowsException<ArgumentException>(() =>
                orderManager.AddNewOrderItem(name, zeroPrice, "Описание"));

            Assert.AreEqual("Цена должна быть положительным числом", exception.Message);
            Assert.AreEqual(0, orderManager.GetMenu().Count); // Меню осталось пустым
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        public void AddNewOrderItem_NameIsNullOrWhiteSpace_ThrowsException(string emptyName)
        {
           
            var orderManager = new OrderManager();
            decimal price = 699;

           
            var exception = Assert.ThrowsException<ArgumentException>(() =>
                orderManager.AddNewOrderItem(emptyName, price, "Описание"));

            Assert.AreEqual("Заполните все обязательные поля", exception.Message);
            Assert.AreEqual(0, orderManager.GetMenu().Count); // Меню осталось пустым
        }
    }
}
