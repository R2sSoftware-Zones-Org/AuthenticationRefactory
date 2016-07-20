using Model.DataAccess;
using Model.Utility;
using System.Data;

namespace Model.Service
{
    public class AuthenticationService
    {
        public IAuthenticationDao MyAuthenticationDao { get; set; }

        //public AuthenticationService()
        //{
        //    this.MyAuthenticationDao = new AuthenticationDao();
        //}

        /// <summary>
        /// 驗證密碼
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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