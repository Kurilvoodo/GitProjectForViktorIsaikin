using Ninject;
using NUnit.Framework;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Ioc;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Tests
{
    [TestFixture]
    public class BookTests
    {
        private static int TestingIdVariable = 1;

        [Test]
        public void AddBookTest()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            Author testAuthor = new Author()
            {
                FirstName = "Aplhonce",
                LastName = "Elrick"
            };
            Book testBook = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-123-12345-X",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1993,
                PublishingHouse = "House",
                Title = "Aclchemy"
            };
            testAuthor.Id = _authorLogic.AddAuthor(testAuthor);
            TestingIdVariable = testBook.Id = _bookLogic.AddBook(testBook, testAuthor.Id);
        }

        [Test]
        public void GetAllBooks()
        {
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Author testAuthor = new Author()
            {
                FirstName = "Aplhonce",
                LastName = "Elrick"
            };
            Book testBook = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-486-16625-X",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1993,
                PublishingHouse = "House",
                Title = "Aclchemy"
            };
            testAuthor.Id = _authorLogic.AddAuthor(testAuthor);
            testBook.Id = _bookLogic.AddBook(testBook, testAuthor.Id);
            Author testAuthor1 = new Author()
            {
                FirstName = "Aplghonce",
                LastName = "Elrickad"
            };
            Book testBook1 = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-163-1123-X",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1993,
                PublishingHouse = "House",
                Title = "Aclchemy"
            };
            testAuthor1.Id = _authorLogic.AddAuthor(testAuthor);
            testBook1.Id = _bookLogic.AddBook(testBook1, testAuthor1.Id);

            Assert.IsNotEmpty(_bookLogic.GetAllBooks());
        }

        [Test]
        public void GetBookById()
        {
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            _bookLogic.GetBookById(TestingIdVariable);
        }

        /*
        [Test]
        public void EditBook()
        {
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            Book editingBook = new Book()
            {
                Id = TestingIdVariable,
                Annotation = "Annotation that is edited",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1993,
                PublishingHouse = "House",
                Title = "Aclchemy"
            };
            _bookLogic.EditBook(editingBook);
            _bookLogic.GetBookById(TestingIdVariable);
        } */

        [Test]
        public void DeleteBookTest()
        {
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            _bookLogic.DeleteBookById(TestingIdVariable);
        }
    }
}