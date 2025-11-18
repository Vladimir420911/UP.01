using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TRegistration
    {
        AuthManager AuthManager_;

        [TestInitialize]
        public void TestInit()
        {
            AuthManager_ = new AuthManager();

            AuthManager_.Register("user1", "login1", "1234", UserRole.Cook);
            AuthManager_.Register("user2", "login2", "12345", UserRole.Cook);
            AuthManager_.Register("user3", "login3", "123456", UserRole.Waiter);
        }

        [TestMethod]
        public void TRegister_ReturnsSuccess()
        {
            var result = AuthManager_.Register("newSotrudnik", "newLogin", "123", UserRole.Waiter);

            Assert.AreEqual(RegistrationResult.Success, result);
        }

        [TestMethod]
        [DataRow("newSotrudnik", "login2", "123", UserRole.Waiter, RegistrationResult.ExistingLogin)]
        [DataRow("user3", "newLogin", "123", UserRole.Cook, RegistrationResult.ExistingUsername)]
        public void TRegister_ReturnsFailure(string username, string login, string password, UserRole role, RegistrationResult expected)
        {
            var result = AuthManager_.Register(username, login, password, role);
                
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("", "login", "123", UserRole.Cook)]
        [DataRow("sotrudnik", "", "123", UserRole.Waiter)]
        [DataRow("sotrudnik", "login", "", UserRole.Waiter)]
        public void TRegister_ReturnsEmptyFields(string username, string login, string password, UserRole role)
        {
            var result = AuthManager_.Register(username, login, password, role);

            Assert.AreEqual(RegistrationResult.EmptyFields, result);
        }


    }
}
