using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class PatentDao : BaseDao, IPatentDao
    {
        public int AddPatent(Patent patent, int authorId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddPatent");
                AddParameter(GetParameter("@AuthorId", authorId, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Country", patent.Country, System.Data.DbType.String), command);
                AddParameter(GetParameter("@RegistrationNumber", patent.RegistrationNumber, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@DateOfApplication", patent.DateOfApplication, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@NumberOfPages", patent.NumberOfPages, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationYear", patent.PublicationDate.Year, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationDate", patent.PublicationDate, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@Annotation", patent.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Title", patent.Title, System.Data.DbType.String), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void DeletePatentById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.DeletePatentById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditPatent(Patent patent, int authorId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.EditPatent");
                AddParameter(GetParameter("@Id", patent.Id, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationYear", patent.PublicationYear, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Country", patent.Country, System.Data.DbType.String), command);
                AddParameter(GetParameter("@RegistrationNumber", patent.RegistrationNumber, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@DateOfApplication", patent.DateOfApplication, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@NumberOfPages", patent.NumberOfPages, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationDate", patent.PublicationDate, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@Annotation", patent.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Title", patent.Title, System.Data.DbType.String), command);
                AddParameter(GetParameter("@AuthorId", authorId, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Patent> GetAllPatent()
        {
            List<Patent> patents = new List<Patent>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllPatents");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patents.Add(GetPatent(reader));
                }
            }
            return patents;
        }

        public Patent GetPatentById(int id)
        {
            Patent patent = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetPatentById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patent = GetPatent(reader);
                }
            }
            return patent;
        }
    }
}