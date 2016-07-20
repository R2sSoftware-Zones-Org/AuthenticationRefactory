using System;
using Model.DataAccess;
using System.Data;

namespace ModelTests.Service
{
    public class mockDao : IAuthenticationDao
    {
        public DataTable QueryPasswordById(string id, string password)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public void UpdatePassword(string id, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}