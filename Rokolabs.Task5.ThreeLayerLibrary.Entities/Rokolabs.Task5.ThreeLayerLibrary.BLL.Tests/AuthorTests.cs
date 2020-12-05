using Ninject;
using NUnit.Framework;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Ioc;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Tests
{
    [TestFixture]
    public class AuthorTests
    {
        private static int TestingIdVariable = 1;

        [Test]
        public void AddAuthor()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Author testAuthor = new Author()
            {
                FirstName = "Test",
                LastName = "Test"
            };
            TestingIdVariable = _authorLogic.AddAuthor(testAuthor);
            Assert.IsNotNull(TestingIdVariable);
        }

        [Test]
        public void GetAuthorById()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            _authorLogic.GetAuthorById(TestingIdVariable);
        }

        [Test]
        public void GetAllAuthors()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Assert.IsNotEmpty(_authorLogic.GetAllAuthors());
        }

        [Test]
        public void GetBooksByAuthorId()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Assert.IsNotEmpty(_authorLogic.GetBooksByAuthorId(24));
        }

        [Test]
        public void GetPatentsByAuthorId()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Assert.IsNotEmpty(_authorLogic.GetPatentsByAuthorId(TestingIdVariable));
        }

        [Test]
        public void GetPatentsAndBooks()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            Author testAuthor = new Author()
            {
                FirstName = "Testalex",
                LastName = "Testzavalni"
            };
            Author testAuthor1 = new Author()
            {
                FirstName = "Test-Alex",
                LastName = "Test-Navalni"
            };
            Book testBook = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-123-12345-X",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1997,
                PublishingHouse = "House",
                Title = "Title"
            };
            Book testBook1 = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-145-1875-X",
                NumberOfPages = 27,
                PlaceOfPublication = "Place",
                PublicationYear = 1995,
                PublishingHouse = "House",
                Title = "Title1"
            };
            Patent testPatent = new Patent()
            {
                Annotation = "Annotation",
                Country = "Country",
                DateOfApplication = new System.DateTime(1993, 11, 1),
                NumberOfPages = 114,
                PublicationDate = new System.DateTime(1993, 12, 2),
                PublicationYear = 1993,
                RegistrationNumber = 153,
                Title = "Title"
            };
            Patent testPatent1 = new Patent()
            {
                Annotation = "Annotation",
                Country = "Country",
                DateOfApplication = new System.DateTime(1996, 5, 5),
                NumberOfPages = 119,
                PublicationDate = new System.DateTime(1996, 5, 6),
                PublicationYear = 1996,
                RegistrationNumber = 193,
                Title = "Title"
            };
            int authorId = _authorLogic.AddAuthor(testAuthor);
            _bookLogic.AddBook(testBook, authorId);
            _patentLogic.AddPatent(testPatent, authorId);
            int author1Id = _authorLogic.AddAuthor(testAuthor1);
            _bookLogic.AddBook(testBook1, author1Id);
            _patentLogic.AddPatent(testPatent1, author1Id);
            Assert.IsNotEmpty(_authorLogic.GetPatentsAndBooksByAuthorId(authorId));
            Assert.IsNotEmpty(_authorLogic.GetPatentsAndBooksByAuthorId(author1Id));
        }

        [Test]
        public void DeleteAuthorById()
        {
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            _authorLogic.DeleteAuthor(TestingIdVariable);
        }
    }
}