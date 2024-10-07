using My_Login_App.API.Enums;
using My_Login_App.API.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace My_Login_App.API.Packages
{
    internal class PKG_USERS : PKG_BASE
    {
        public void AddUser(User user)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.add_user";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_email", OracleDbType.Varchar2).Value = user.Email;
            cmd.Parameters.Add("v_username", OracleDbType.Varchar2).Value = user.Username;
            cmd.Parameters.Add("v_password", OracleDbType.Varchar2).Value = user.Password;
            cmd.Parameters.Add("v_role", OracleDbType.Int32).Value = user.Role;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public User GetUser(string username)
        {
            User user = null;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.get_user_by_username";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_username", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add("v_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                user = new User()
                {

                    Email = reader["email"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Role = (Role)int.Parse(reader["role"].ToString()),
                };
            }

            conn.Close();

            return user;
        }
    }
}
