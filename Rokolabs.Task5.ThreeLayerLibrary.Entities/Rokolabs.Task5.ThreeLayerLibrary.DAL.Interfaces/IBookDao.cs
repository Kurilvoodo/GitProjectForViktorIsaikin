using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface IBookDao
    {
        Book GetBookById(int id);

        ILookup<string, Book> FindAllBooksByPublishingHouse(string partPublishingHouseName);

        IEnumerable<Book> GetAllBooks();

        int AddBook(Book book, int authorId);

        void DeleteBookById(int id);

        void EditBook(Book book, int authorId);
    }
}