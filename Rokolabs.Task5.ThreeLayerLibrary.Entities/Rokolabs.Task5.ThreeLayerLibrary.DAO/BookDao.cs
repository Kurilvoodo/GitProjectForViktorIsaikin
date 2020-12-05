using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class BookDao : BaseDao, IBookDao
    {
        public int AddBook(Book book, int authorId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddBook");
                AddParameter(GetParameter("@AuthorId", authorId, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@ISBN", book.ISBN, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublicationYear", book.PublicationYear, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Title", book.Title, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Annotation", book.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PlaceOfPublication", book.PlaceOfPublication, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublishingHouse", book.PublishingHouse, System.Data.DbType.String), command);
                AddParameter(GetParameter("@NumberOfPages", book.NumberOfPages, System.Data.DbType.Int32), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void DeleteBookById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.DeleteBookById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditBook(Book book, int authorId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.EditBook");
                AddParameter(GetParameter("@Id", book.Id, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@PublicationYear", book.PublicationYear, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@Title", book.Title, System.Data.DbType.String), command);
                AddParameter(GetParameter("@Annotation", book.Annotation, System.Data.DbType.String), command);
                AddParameter(GetParameter("@ISBN", book.ISBN, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PlaceOfPublication", book.PlaceOfPublication, System.Data.DbType.String), command);
                AddParameter(GetParameter("@PublishingHouse", book.PublishingHouse, System.Data.DbType.String), command);
                AddParameter(GetParameter("@NumberOfPages", book.NumberOfPages, System.Data.DbType.Int32), command);
                AddParameter(GetParameter("@AuthorId", authorId, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
                
            }
        }

        private DataTable GetAuthorsIdForBook(int bookId, List<int> authorsId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AuthorId");
            dt.Columns.Add("Bookid");
            foreach (var item in authorsId)
            {
                dt.Rows.Add(item, bookId);
            }
            return dt;
        }

        public ILookup<string, Book> FindAllBooksByPublishingHouse(string partPublishingHouseName)
        {
            List<Book> package = new List<Book>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.FindAllBooksByPublishingHouse");
                AddParameter(GetParameter("@partPublishingHouseName", partPublishingHouseName, System.Data.DbType.String), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    package.Add(GetBook(reader));
                }
                return package.Where(t => t.PublishingHouse.StartsWith(partPublishingHouseName)).ToLookup(t => t.PublishingHouse);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllBooks");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(GetBook(reader));
                }
                return books;
            }
        }

        public Book GetBookById(int id)
        {
            Book book = null;
            var _authorLogic = new AuthorDao();
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetBookById");
                AddParameter(GetParameter("@Id", id, System.Data.DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    book = GetBook(reader);
                }
            }
            book.AuthorsId = _authorLogic.GetAuthorsIdsByBookId(book.Id);
            return book;
        }
    }
}