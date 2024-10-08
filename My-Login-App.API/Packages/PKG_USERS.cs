using My_Login_App.API.Enums;
using My_Login_App.API.Interfaces;
using My_Login_App.API.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace My_Login_App.API.Packages
{
    public class PKG_USERS : PKG_BASE, IPKG_BASE<UserRequest, UserResponse>
    {
        public PKG_USERS(IConfiguration configuration) : base(configuration)
        {
        }

        public void AddEntity(UserRequest user)
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

        public void UpdateEntity(int id, UserRequest user)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.update_user";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("v_email", OracleDbType.Varchar2).Value = user.Email;
            cmd.Parameters.Add("v_username", OracleDbType.Varchar2).Value = user.Username;
            cmd.Parameters.Add("v_password", OracleDbType.Varchar2).Value = user.Password;
            cmd.Parameters.Add("v_role", OracleDbType.Int32).Value = user.Role;

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public void DeleteEntity(int id)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.delete_user";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public UserResponse GetEntity(int id)
        {
            UserResponse user = null;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.get_user_by_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("v_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                user = new UserResponse()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Email = reader["email"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Role = (Role)int.Parse(reader["role"].ToString()),
                };
            }

            conn.Close();

            return user;
        }

        public UserResponse GetEntityByProperty(string username)
        {
            UserResponse user = null;
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
                user = new UserResponse()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Email = reader["email"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Role = (Role)int.Parse(reader["role"].ToString()),
                };
            }

            conn.Close();

            return user;
        }

        public List<UserResponse> GetAllEntities()
        {
            List<UserResponse> users = new List<UserResponse>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_USERS.get_all_users";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserResponse user = new UserResponse()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Email = reader["email"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Role = (Role)int.Parse(reader["role"].ToString()),
                };

                users.Add(user);
            }

            conn.Close();
            return users;
        }
    }
}
