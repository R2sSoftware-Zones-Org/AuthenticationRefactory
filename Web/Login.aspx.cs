using Model.DataAccess;
using Model.Service;
using Model.Utility;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Vefify_Click(object sender, EventArgs e)
    {
        string id = this.Id.Text;
        string password = this.Password.Text;

        AuthenticationService authenticationService = new AuthenticationService();

        authenticationService.MyAuthenticationDao = new AuthenticationDao();

        var status = authenticationService.VerifyPasswordById(id, password);

        string result = string.Empty;

        switch (status)
        {
            case VerifyStatus.Passed:
            case VerifyStatus.Failed:
                result = status.ToString();
                break;

            case VerifyStatus.NoExist:
                result = "帳號或密碼輸入錯誤";
                break;

            case VerifyStatus.None:

            default:
                break;
        }
        this.Result.Text = result;
    }
}