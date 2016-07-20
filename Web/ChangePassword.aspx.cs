using Model.Service;
using Model.Utility;
using System;

public partial class ChangePassword : System.Web.UI.Page
{
    public AuthenticationService MyAuthenticationService { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        MyAuthenticationService = new AuthenticationService();
    }

    protected void Modify_Click(object sender, EventArgs e)
    {
        string id = Convert.ToString(Session["UserId"]);
        string password = this.OriginalPassword.Text; ;

        string newPassword = this.NewPassword.Text;
        string confirmPassword = this.ConfirmPassword.Text;

        string result = string.Empty;

        if (this.VerifyPassword(id, password))
        {
            if (CheckPasswordSame(newPassword, confirmPassword))
            {
                this.SaveNewPassword(id, newPassword);
            }
            else
            {
                //新密碼與確認密碼不符
                result = "新密碼與確認密碼不符";
            }
        }
        else
        {
            //帳號與密碼不符
            result = "帳號與密碼不符";
        }

        Result.Text = result;
    }

    /// <summary>
    /// 將新密碼存入DB
    /// </summary>
    /// <param name="newPassword"></param>
    private void SaveNewPassword(string id, string newPassword)
    {
        string result = string.Empty;

        try
        {
            MyAuthenticationService.UpdatePassword(id, newPassword);
            result = "更新密碼成功";
        }
        catch (Exception)
        {
            result = "更新密碼失敗";
        }
    }

    /// <summary>
    /// 檢查新密碼與確認密碼是否相同
    /// </summary>
    /// <param name="newPassword"></param>
    /// <param name="confirmPassword"></param>
    /// <returns></returns>
    private bool CheckPasswordSame(string newPassword, string confirmPassword)
    {
        return newPassword == confirmPassword;
    }

    /// <summary>
    /// 檢查原始密碼是否合法
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool VerifyPassword(string id, string password)
    {
        var status = MyAuthenticationService.VerifyPasswordById(id, password);

        return (status == VerifyStatus.Passed);

        throw new NotImplementedException();
    }
}