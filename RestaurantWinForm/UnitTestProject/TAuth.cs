using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TAuth
    {

        private Mock<IStaffRepository> _mockStaffRepo;
        private AuthManager _authManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockStaffRepo = new Mock<IStaffRepository>();
            _authManager = new AuthManager(_mockStaffRepo.Object);
        }

        [TestMethod]
        public void Login_ValidWaiterCredentials_ReturnsTrue()
        {
            // Arrange
            var waiter = new Staff(1);
            waiter.Username = "ivanov";
            waiter.Password = "password123";
            waiter.Role = UserRole.Waiter;

            _mockStaffRepo.Setup(repo => repo.GetByUsername("ivanov"))
                          .Returns(waiter);

            // Act
            bool result = _authManager.Login("ivanov", "password123");

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(UserRole.Waiter, _authManager.CurrentUser.Role);
            Assert.AreEqual("ivanov", _authManager.CurrentUser.Username);
        }

        [TestMethod]
        public void Login_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            _mockStaffRepo.Setup(repo => repo.GetByUsername("unknown"))
                          .Returns((Staff)null);

            // Act
            bool result = _authManager.Login("unknown", "password123");

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(_authManager.CurrentUser);
        }


    }
}
