using System;
using System.Data;
using System.Data.SqlClient;


public class AuthenticationDao
{
    public DataTable QueryPasswordById(string id, string password)
    {
        DataTable dt = new DataTable();

        string connectionString = @"MyConnectionString";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            cn.Open();
            string sqlStatement = @"Select Password From Users Where ID=id";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, cn);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            adapter.Fill(dt);
        }

        return dt;
    }

    internal void UpdatePassword(string id, string newPassword)
    {
        throw new NotImplementedException();
    }
}
