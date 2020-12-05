using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface IAuthorDao
    {
        IEnumerable<Book> GetBooksByAuthorId(int idAuthor);

        IEnumerable<Patent> GetPatentsByAuthorId(int idAuthor);

        IEnumerable<PrintEdition> GetPatentsAndBooksByAuthorId(int idAuthor);

        IEnumerable<Author> GetAllAuthors();

        IEnumerable<Author> GetAuthorByBookId(int bookId);

        IEnumerable<Author> GetAuthorByPatentId(int patentId);

        List<int> GetAuthorsIdsByBookId(int bookId);

        Author GetAuthorById(int idAuthor);

        int AddAuthor(Author author);

        void DeleteAuthor(int authorId);

        void EditAuthor(Author author);

        List<Author> GetAuthorsBySearchTextForList(string searchText);

        List<Author> GetAuthorsByIdForListForBook(int bookId);

        List<Author> GetAuthorsByIdForListForPatent(int patentId);
    }
}