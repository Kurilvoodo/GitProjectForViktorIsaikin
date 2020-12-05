using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces
{
    public interface IAuthorLogic
    {
        IEnumerable<Book> GetBooksByAuthorId(int idAuthor);

        IEnumerable<Patent> GetPatentsByAuthorId(int idAuthor);

        IEnumerable<PrintEdition> GetPatentsAndBooksByAuthorId(int idAuthor);

        IEnumerable<Author> GetAllAuthors();

        IEnumerable<Author> GetAuthorByBookId(int bookId);

        List<int> GetAuthorsIdsByBookid(int bookId);

        IEnumerable<Author> GetAuthorByPatentId(int patentId);

        Author GetAuthorById(int idAuthor);

        int AddAuthor(Author author);

        void DeleteAuthor(int authorId);

        void EditAuthor(Author author);

        List<SelectListSerialization> GetAuthorsBySearchTextForList(string searchText);

        List<SelectListSerialization> GetAuthorsByIdForListForBook(int bookId);

        List<SelectListSerialization> GetAuthorsByIdForListForPatent(int patentId);
    }
}