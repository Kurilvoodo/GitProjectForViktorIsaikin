using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class NewspaperDao : BaseDao, INewspaperDao
    {
        public int AddNewspaper(Newspaper newspaper)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddNewspaper");
                AddParameter(GetParameter("@ISSN", newspaper.ISSN, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublicationYear", newspaper.PublicationYear, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Title", newspaper.Title, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Annotation", newspaper.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PlaceOfPublication", newspaper.PlaceOfPublication, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublishingHouse", newspaper.PublishingHouse, System.Data.DbType.String), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteNewspaperById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.DeleteNewspaperById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditNewspaper(Newspaper newspaper)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.EditNewspaper");
                AddParameter(GetParameter("@Id", newspaper.Id, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationYear", newspaper.PublicationYear, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Title", newspaper.Title, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Annotation", newspaper.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PlaceOfPublication", newspaper.PlaceOfPublication, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublishingHouse", newspaper.PublishingHouse, System.Data.DbType.String), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Newspaper> GetAllNewspapers()
        {
            List<Newspaper> newspapers = new List<Newspaper>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllNewspapers");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newspapers.Add(GetNewspaper(reader));
                }
            }
            return newspapers;
        }

        public Newspaper GetNewspaperById(int id)
        {
            Newspaper newspaper = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetNewspaperById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newspaper = GetNewspaper(reader);
                }
            }
            return newspaper;
        }
    }
}