using Model.DataAccess;
using Model.Utility;
using System;
using System.Data;

namespace Model.Service
{
    public class AuthenticationService
    {
        public AuthenticationDao MyAuthenticationDao { get; private set; }

        public AuthenticationService()
        {
            this.MyAuthenticationDao = new AuthenticationDao();
        }

        public VerifyStatus VerifyPasswordById(string id, string password)
        {

            DataTable dt = MyAuthenticationDao.QueryPasswordById(id, password);

            if (dt.Rows.Count > 0)
            {
                if (password == dt.Rows[0]["Password"].ToString())
                {
                    return VerifyStatus.Passed;
                }
                else
                {
                    return VerifyStatus.Failed;
                }
            }
            else
            {
                return VerifyStatus.NoExist;
            }
        }

        public void UpdatePassword(string id, string newPassword)
        {

            MyAuthenticationDao.UpdatePassword(id, newPassword);
        }
    }
}