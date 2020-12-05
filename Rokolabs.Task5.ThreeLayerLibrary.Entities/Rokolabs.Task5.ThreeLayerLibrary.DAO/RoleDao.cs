using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class RoleDao : BaseDao, IRoleDao
    {
        public IEnumerable<Roles> GetAllRoles()
        {
            List<Roles> roles = new List<Roles>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAllRoles");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Roles()
                    {
                        Id = (int)reader["Id"],
                        RoleName = reader["RoleName"] as string
                    });
                }
            }
            return roles;
        }

        public string GetUserRoleById(int id)
        {
            string result = "";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetUserRole");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["RoleName"] as string;
                }
            }
            return result;
        }
    }
}