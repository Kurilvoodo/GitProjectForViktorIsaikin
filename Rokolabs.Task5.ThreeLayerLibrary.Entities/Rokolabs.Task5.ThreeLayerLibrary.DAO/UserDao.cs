using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class UserDao : BaseDao, IUserDao
    {
        public int AddUser(User user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddUser");
                AddParameter(GetParameter("@Username", user.Username, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Password", user.Password, System.Data.DbType.Binary), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.DeleteUser");
                AddParameter(GetParameter("@Id", userId, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllUsers");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(GetUser(reader));
                }
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetUserById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = GetUser(reader);
                }
            }
            return user;
        }

        public int GetUserIdByUsername(string username)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetUserIdByUsername");
                AddParameter(GetParameter("@Username", username, System.Data.DbType.String), command);
                connection.Open();
                var result = command.ExecuteScalar();
                return (int)result;
            }
        }

        public string GetUserRole(int id)
        {
            string roleToReturn = "";
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetUserRole");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roleToReturn = reader["RoleName"] as string;
                }
            }
            return roleToReturn;
        }

        public void GiveRoleToUser(int userId, int websiteRoleId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GiveRoleToUser");
                AddParameter(GetParameter("@UserId", userId, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@WebsiteRoleId", websiteRoleId, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Login(User user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.Login");
                AddParameter(GetParameter("@Username", user.Username, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Password", user.Password, System.Data.DbType.Binary), command);
                connection.Open();
                var resultCommand = command.ExecuteScalar();
                return (int)resultCommand > 0;
            }
        }
    }
}