using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model.DataAccess
{
    public class AuthenticationDaoForOracle : IAuthenticationDao
    {
        public DataTable QueryPasswordById(string id, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string id, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
