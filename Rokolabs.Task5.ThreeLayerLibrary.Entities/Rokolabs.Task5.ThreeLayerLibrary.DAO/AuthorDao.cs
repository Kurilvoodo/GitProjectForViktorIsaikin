using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class AuthorDao : BaseDao, IAuthorDao
    {
        public IEnumerable<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllAuthors");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            List<Book> books = new List<Book>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetBooksByAuthorId");
                AddParameter(GetParameter("@AuthorId", authorId, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(GetBook(reader));
                }
            }
            return books;
        }

        public Author GetAuthorById(int authorId)
        {
            Author author = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAuthorById");
                AddParameter(GetParameter("@AuthorId", authorId, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    author = GetAuthor(reader);
                }
            }
            return author;
        }

        public IEnumerable<Patent> GetPatentsByAuthorId(int authorId)
        {
            List<Patent> patents = new List<Patent>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetPatentsByAuthorId");
                AddParameter(GetParameter("@AuthorId", authorId, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patents.Add(GetPatent(reader));
                }
            }
            return patents;
        }

        #region Not  Implemented

        public IEnumerable<PrintEdition> GetPatentsAndBooksByAuthorId(int idAuthor)
        {
            List<PrintEdition> patentsAndBooks = new List<PrintEdition>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetPatentsAndBooksByAuthorId");
                AddParameter(GetParameter("@AuthorId", idAuthor, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    switch ((string)reader["Type"])
                    {
                        case BookCaseType:
                            patentsAndBooks.Add(GetBook(reader));
                            break;

                        case PatentCaseType:
                            patentsAndBooks.Add(GetPatent(reader));
                            break;
                    }
                }
            }
            return patentsAndBooks;
        }

        public int AddAuthor(Author author)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.AddAuthor");
                AddParameter(GetParameter("@FirstName", author.FirstName, DbType.String), command);
                AddParameter(GetParameter("@LastName", author.LastName, DbType.String), command);
                connection.Open();
                int AuthorId = (int)(decimal)command.ExecuteScalar();
                return AuthorId;
            }
        }

        public void DeleteAuthor(int authorId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.DeleteAuthorById");
                AddParameter(GetParameter("@AuthorId", authorId, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Author> GetAuthorByBookId(int bookId)
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByBookId");
                AddParameter(GetParameter("@BookId", bookId, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        public IEnumerable<Author> GetAuthorByPatentId(int patentId)
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByPatentId");
                AddParameter(GetParameter("@PatentId", patentId, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        public void EditAuthor(Author author)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.EditAuthor");
                AddParameter(GetParameter("@Id", author.Id, DbType.Int32), command);
                AddParameter(GetParameter("FirstName", author.FirstName, DbType.String), command);
                AddParameter(GetParameter("LastName", author.LastName, DbType.String), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<int> GetAuthorsIdsByBookId(int bookId)
        {
            List<int> returningHashset = new List<int>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByBookId");
                AddParameter(GetParameter("@BookId", bookId, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returningHashset.Add((int)reader["Id"]);
                }
            }
            return returningHashset;
        }

        public ISet<int> GetAuthorsIdsByPatentId(int patentId)
        {
            HashSet<int> returningHashset = new HashSet<int>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByPatentId");
                AddParameter(GetParameter("@PatentId", patentId, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returningHashset.Add((int)reader["Id"]);
                }
            }
            return returningHashset;
        }

        public List<Author> GetAuthorsBySearchTextForList(string searchText)
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorBySearchText");
                AddParameter(GetParameter("@SearchText", searchText, DbType.String), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        public List<Author> GetAuthorsByIdForListForBook(int id)
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByBookId");
                AddParameter(GetParameter("@BookId", id, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        public List<Author> GetAuthorsByIdForListForPatent(int id)
        {
            List<Author> authors = new List<Author>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetAuthorByPatentId");
                AddParameter(GetParameter("@PatentId", id, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(GetAuthor(reader));
                }
            }
            return authors;
        }

        #endregion Not  Implemented
    }
}