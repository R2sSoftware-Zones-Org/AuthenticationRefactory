using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Utility;
using ModelTests.Service;

namespace Model.Service.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void VerifyPasswordByIdTest_Without_Data()
        {
            //Arrange

            AuthenticationService target = new AuthenticationService();
            target.MyAuthenticationDao = new mockDao();

            string id = string.Empty;
            string password = string.Empty;

            VerifyStatus expected =  VerifyStatus.NoExist;
            VerifyStatus actual;

            //Act
            actual = target.VerifyPasswordById(id, password);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}