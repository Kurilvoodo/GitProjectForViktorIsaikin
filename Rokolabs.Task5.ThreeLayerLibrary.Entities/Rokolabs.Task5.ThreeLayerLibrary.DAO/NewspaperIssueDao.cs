using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class NewspaperIssueDao : BaseDao, INewspaperIssueDao
    {
        public int AddNewspaperIssue(NewspaperIssue newspaperIssue, int newspaperId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddNewspaperIssue");
                AddParameter(GetParameter("@NewspaperId", newspaperId, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@ReleaseDate", newspaperIssue.ReleaseDate, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@ReleaseNumber", newspaperIssue.ReleaseNumber, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@NumberOfPages", newspaperIssue.NumberOfPages, System.Data.DbType.Int32), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteNewspaperIssue(int newspaperIssueId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.DeleteNewspaperIssue");
                AddParameter(GetParameter("@Id", newspaperIssueId, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<NewspaperIssue> GetAllNewspaperIssuesByNewspaperId(int newspaperId)
        {
            List<NewspaperIssue> newspaperIssues = new List<NewspaperIssue>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllNewspaperIssuesByNewspaperId");
                AddParameter(GetParameter("@NewspaperId", newspaperId, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newspaperIssues.Add(GetNewspaperIssue(reader));
                }
            }
            return newspaperIssues;
        }

        public NewspaperIssue GetNewspaperIssueById(int id)
        {
            NewspaperIssue newspaperIssue = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetNewspaperIssueById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newspaperIssue = GetNewspaperIssue(reader);
                }
            }
            return newspaperIssue;
        }

        #region NotImplemented

        public void EditNewspaperIssue(NewspaperIssue newspaperIssue)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddNewspaperIssue");
                AddParameter(GetParameter("@NewspaperIssueId", newspaperIssue.Id, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@ReleaseDate", newspaperIssue.ReleaseDate, System.Data.DbType.DateTime), command);
                AddParameter(GetParameter("@ReleaseNumber", newspaperIssue.ReleaseNumber, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@NumberOfPages", newspaperIssue.NumberOfPages, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #endregion NotImplemented
    }
}