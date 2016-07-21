using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DataAccess;
using Model.Utility;
using ModelTests.Service;
using Rhino.Mocks;
using System.Data;

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

            VerifyStatus expected = VerifyStatus.NoExist;
            VerifyStatus actual;

            //Act
            actual = target.VerifyPasswordById(id, password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void VerifyPasswordByIdTest_Id_Equals_Alex_Password_1234_Should_Passed()
        {
            //Arrange

            AuthenticationService target = new AuthenticationService();

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Password", typeof(string));
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["Password"] = "1234";
            dt.Rows.Add(dr);

            //Stub物件初使化
            IAuthenticationDao stubDao = MockRepository.GenerateStub<IAuthenticationDao>();
            stubDao.Stub(x => x.QueryPasswordById("Alex", "1234")).Return(dt);
            target.MyAuthenticationDao = stubDao;

            string id = "Alex";
            string password = "1234";           

            VerifyStatus expected = VerifyStatus.Passed;
            VerifyStatus actual;

            //Act
            actual = target.VerifyPasswordById(id, password);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}