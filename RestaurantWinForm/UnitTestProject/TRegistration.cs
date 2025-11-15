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
        private readonly List<Staff> _existingStaff = new List<Staff>();
        [TestInitialize]
        public void TestInit()
        {
            var staff1 = new Staff(1, "1234");
            staff1.UserName = "user1";
            staff1.Login = "login1";
            staff1.Role = UserRole.Waiter;

            _existingStaff.Add(staff1);

            var staff2 = new Staff(2, "12345");
            staff2.UserName = "user2";
            staff2.Login = "login2";
            staff2.Role = UserRole.Waiter;

            _existingStaff.Add(staff2);

            var staff3 = new Staff(3, "123456");
            staff3.UserName = "user3";
            staff3.Login = "login3";
            staff3.Role = UserRole.Waiter;

            _existingStaff.Add(staff3);
        }
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
    }
}
