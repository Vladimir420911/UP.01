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
        public void Login_ValidWaiterCredentials_ReturnsSuccess()
        {
            var waiter = new Staff(1, "password123");
            waiter.Username = "ivanov";
            waiter.Role = UserRole.Waiter;

            _mockStaffRepo.Setup(repo => repo.GetByUsername("ivanov"))
                          .Returns(waiter);

            LoginResult result = _authManager.Login("ivanov", "password123");

            Assert.AreEqual(LoginResult.Success, result);
            Assert.AreEqual(UserRole.Waiter, _authManager.CurrentUser.Role);
            Assert.AreEqual("ivanov", _authManager.CurrentUser.Username);
        }

        [TestMethod]
        public void Login_InvalidLogin_ReturnsWrongLogin()
        {
            _mockStaffRepo.Setup(repo => repo.GetByUsername("unknown"))
                          .Returns((Staff)null);

            LoginResult result = _authManager.Login("unknown", "password123");

            Assert.AreEqual(LoginResult.WrongLogin, result);
            Assert.IsNull(_authManager.CurrentUser);
        }

        [TestMethod]
        public void Login_InvalidPassword_ReturnsWrongPassword()
        {
            var waiter = new Staff(1, "password123");
            waiter.Username = "ivanov";
            waiter.Role = UserRole.Waiter;

            _mockStaffRepo.Setup(repo => repo.GetByUsername("ivanov"))
                          .Returns(waiter);

            LoginResult result = _authManager.Login("ivanov", "wrongpassword");

            Assert.AreEqual(LoginResult.WrongPassword, result);
            Assert.IsNull(_authManager.CurrentUser);
        }

        [TestMethod]
        public void Login_ValidChefCredentials_ReturnsSuccess()
        {
            var chef = new Staff(1, "kitchen123");
            chef.Username = "chef_alex";

            chef.Role = UserRole.Chef;

            _mockStaffRepo.Setup(repo => repo.GetByUsername("chef_alex"))
                          .Returns(chef);

            LoginResult result = _authManager.Login("chef_alex", "kitchen123");

            Assert.AreEqual(LoginResult.Success, result);
            Assert.AreEqual(UserRole.Chef, _authManager.CurrentUser.Role);
            Assert.AreEqual("chef_alex", _authManager.CurrentUser.Username);
        }

        [TestMethod]
        public void LoginAndPasswordIsWhiteSpace_ReturnsPasswordOrLoginIsWhiteSpace()
        {
            var waiter = new Staff(1, "123");
            waiter.Login = "Login1";
            waiter.Username = "staff_member1";
            waiter.Role = UserRole.Waiter;

            _mockStaffRepo.Setup(repo => repo.GetByUsername("staff_member1"))
                          .Returns(waiter);

            LoginResult resEmptyLogin = _authManager.Login("", "123");
            LoginResult resEmptyPassword = _authManager.Login("Login1", "");
            LoginResult resWhitespaceLoginAndPassword = _authManager.Login("  ", "  ");

            Assert.AreEqual(LoginResult.PasswordOrLoginIsWhiteSpace, resEmptyLogin);
            Assert.AreEqual(LoginResult.PasswordOrLoginIsWhiteSpace, resEmptyPassword);
            Assert.AreEqual(LoginResult.PasswordOrLoginIsWhiteSpace, resWhitespaceLoginAndPassword);
        }
    }
}
