using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class BaseDao
    {
        //private string _connectionString = @"Data Source=DESKTOP-M42V6GP\SQLEXPRESS;Initial Catalog=RokolabsLibraryTestDBO;Integrated Security=True";
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

        protected const string PatentCaseType = "Patent";
        protected const string BookCaseType = "Book";
        protected const string NewspaperCaseType = "Newspaper";
        protected const string NewspaperIssueCaseType = "NewspaperIssue";

        //public string ConnectionString { get => _connectionString; }

        public SqlParameter GetParameter(string parameterName, object value, DbType mytype)
        {
            return new SqlParameter()
            {
                DbType = mytype,
                ParameterName = parameterName,
                Value = value,
                Direction = ParameterDirection.Input
            };
        }

        public SqlCommand GetCommand(SqlConnection connection, string commandText)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            return command;
        }

        public void AddParameter(SqlParameter myParam, SqlCommand myCommand)
        {
            myCommand.Parameters.Add(myParam);
        }

        protected static User GetUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = (int)reader["Id"],
                Username = reader["Username"] as string
            };
        }

        protected static Book GetBook(SqlDataReader reader)
        {
            return new Book()
            {
                Id = (int)reader["Id"],
                Title = reader["Title"] as string,
                Annotation = reader["Annotation"] as string,
                PublicationYear = (int)reader["PublicationYear"],
                ISBN = reader["ISBN"] as string,
                PublishingHouse = reader["PublishingHouse"] as string,
                PlaceOfPublication = reader["PlaceOfPublication"] as string,
                NumberOfPages = (int)reader["NumberOfPages"]
            };
        }

        protected static Patent GetPatent(SqlDataReader reader)
        {
            return new Patent()
            {
                Id = (int)reader["Id"],
                Country = reader["Country"] as string,
                RegistrationNumber = (int)reader["RegistrationNumber"],
                DateOfApplication = (DateTime)reader["DateOfApplication"],
                Title = reader["Title"] as string,
                PublicationYear = (int)reader["PublicationYear"],
                NumberOfPages = (int)reader["NumberOfPages"],
                PublicationDate = (DateTime)reader["PublicationDate"],
                Annotation = reader["Annotation"] as string
            };
        }

        protected static Author GetAuthor(SqlDataReader reader)
        {
            return new Author()
            {
                Id = (int)reader["Id"],
                FirstName = reader["FirstName"] as string,
                LastName = reader["LastName"] as string
            };
        }

        protected static Newspaper GetNewspaper(SqlDataReader reader)
        {
            return new Newspaper()
            {
                Id = (int)reader["Id"],
                PublicationYear = (int)reader["PublicationYear"],
                Title = reader["Title"] as string,
                Annotation = reader["Annotation"] as string,
                ISSN = reader["ISSN"] as string,
                PlaceOfPublication = reader["PlaceOfPublication"] as string,
                PublishingHouse = reader["PublishingHouse"] as string
            };
        }

        protected static NewspaperIssue GetNewspaperIssue(SqlDataReader reader)
        {
            return new NewspaperIssue()
            {
                Id = (int)reader["Id"],
                NewspaperId = (int)reader["NewspaperId"],
                ReleaseNumber = (int)reader["ReleaseNumber"],
                NumberOfPages = (int)reader["NumberOfPages"],
                ReleaseDate = (DateTime)reader["ReleaseDate"]
            };
        }
    }
}