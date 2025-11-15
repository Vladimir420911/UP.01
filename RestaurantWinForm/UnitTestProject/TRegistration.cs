using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class TRegistration
    {
        [TestMethod]
        public void TRegisterReturnsSuccess()
        {
            var mockRepo = new Mock<IStaffRepository>();

            mockRepo.Setup(repo => repo.GetUserByLogin("newSotrudnikLogin"))
                    .Returns((Staff)null);

            mockRepo.Setup(repo => repo.Register("newSotrudnik", "newSotrudnikLogin", "123", UserRole.Waiter))
                    .Returns(RegistrationResult.Success);

            var result = mockRepo.Object.Register("newSotrudnik", "newSotrudnikLogin", "123", UserRole.Waiter);

            Assert.AreEqual(RegistrationResult.Success, result);
        }

        [TestMethod]
        public void TRegisterReturnsExistingLogin()
        {
            var mockRepo = new Mock<IStaffRepository>();
            var existingUser = new Staff(1, "123");
            existingUser.UserName = "user1";
            existingUser.Login = "login1";
            existingUser.Role = UserRole.Waiter;

            mockRepo.Setup(repo => repo.GetUserByLogin("login1"))
                    .Returns(existingUser);

            mockRepo.Setup(repo => repo.Register("newSotrudnik", "login2", "123", UserRole.Waiter))
                    .Returns(RegistrationResult.ExistingLogin);

            var result = mockRepo.Object.Register("newSotrudnik", "login2", "123", UserRole.Waiter);

            Assert.AreEqual(RegistrationResult.ExistingLogin, result);
        }

        [TestMethod]
        public void TRegisterReturnsExistingUsername()
        {
            var mockRepo = new Mock<IStaffRepository>();

            mockRepo.Setup(repo => repo.Register("newSotrudnik", "login2", "123", UserRole.Waiter))
                    .Returns(RegistrationResult.ExistingUsername);

            var result = mockRepo.Object.Register("user2", "newSotrudnikLogin", "123", UserRole.Waiter);

            Assert.AreEqual(RegistrationResult.ExistingUsername, result);
        }
    }
}
