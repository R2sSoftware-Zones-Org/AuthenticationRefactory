using System.Data;

namespace Model.DataAccess
{
    public interface IAuthenticationDao
    {
        DataTable QueryPasswordById(string id, string password);
        void UpdatePassword(string id, string newPassword);
    }
}