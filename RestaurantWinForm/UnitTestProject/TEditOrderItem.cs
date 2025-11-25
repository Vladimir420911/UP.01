using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEditOrderItem
{
    [TestClass]
    public class TEditOrderItem
    {
        private OrderManager orderManager_;

        [TestInitialize]
        public void TestInitialize()
        {
            orderManager_ = new OrderManager();

            orderManager_.AddOrderItemToMenu(new OrderItem(1, "Пицца маргарита", 800, "Это пицца, готовится так то, тут столько то калорий"));
        }

        [TestMethod]
        public void EditOrderItem_ValidData_UpdatesItemAndReturnsSuccessMessage()
        {
            // Arrange

            int id = 1;
            string newName = "Пицца НеМаргарита";
            decimal newPrice = 1000;
            string newDescription = "Это другая пицца, готовится по другому, тут другие калории";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newName, result.Name);
            Assert.AreEqual(newPrice, result.Price);
            Assert.AreEqual(newDescription, result.Description);
        }

        [TestMethod]
        public void EditOrderItem_NegativePrice_ReturnsErrorMessage()
        {

            int id = 1;
            string newName = "Пицца НеМаргарита";
            decimal newPrice = -1000;
            string newDescription = "Это другая пицца, готовится по другому, тут другие калории";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditOrderItem_ZeroPrice_ReturnsErrorMessage()
        {

            int id = 1;
            string newName = "Пицца НеМаргарита";
            decimal newPrice = 0;
            string newDescription = "Это другая пицца, готовится по другому, тут другие калории";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditOrderItem_EmptyFields_ReturnsErrorMessage()
        {

            int id = 1;
            string newName = "";
            decimal newPrice = 500;
            string newDescription = "";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditOrderItem_WhiteSpaceFields_ReturnsErrorMessage()
        {

            int id = 1;
            string newName = "   ";
            decimal newPrice = 500;
            string newDescription = "   ";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditOrderItem_NonExistentId_ReturnsNull()
        {

            int id = 999; // Несуществующий ID
            string newName = "Пицца НеМаргарита";
            decimal newPrice = 1000;
            string newDescription = "Это другая пицца, готовится по другому, тут другие калории";

            // Act
            var result = orderManager_.EditOrderItem(id, newName, newPrice, newDescription);

            // Assert
            Assert.IsNull(result);
        }
    }
}