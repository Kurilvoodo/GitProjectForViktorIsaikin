using Ninject;
using NUnit.Framework;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Ioc;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Tests
{
    [TestFixture]
    public class PatentTests
    {
        private static int TestingIdVariable = 1;

        [Test]
        public void AddPatent()
        {
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Author author = new Author()
            {
                FirstName = "Alexander",
                LastName = "Zavalski"
            };
            Patent patent = new Patent()
            {
                Country = "Countrytest",
                RegistrationNumber = 121823821,
                PublicationDate = new System.DateTime(1933, 5, 6),
                DateOfApplication = new System.DateTime(1993, 5, 3),
                NumberOfPages = 122,
                Annotation = "Annotation",
                Title = "TestPatentTitle"
            };
            author.Id = _authorLogic.AddAuthor(author);
            TestingIdVariable = _patentLogic.AddPatent(patent, author.Id);
            Assert.IsNotNull(TestingIdVariable);
            //_authorLogic.DeleteAuthor(author.Id);
        }

        [Test]
        public void GetPatent()
        {
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            _patentLogic.GetPatentById(TestingIdVariable);
        }

        [Test]
        public void GetAllPatents()
        {
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            Author author = new Author()
            {
                FirstName = "Alexander",
                LastName = "Zavalski"
            };
            Patent patent = new Patent()
            {
                Country = "Countrytest",
                RegistrationNumber = 121823821,
                PublicationDate = new System.DateTime(1933, 5, 10),
                DateOfApplication = new System.DateTime(1993, 5, 6),
                NumberOfPages = 122,
                Annotation = "Annotation",
                Title = "TestPatentTitle"
            };
            author.Id = _authorLogic.AddAuthor(author);
            _patentLogic.AddPatent(patent, author.Id);
            Author author1 = new Author()
            {
                FirstName = "Kirril",
                LastName = "Meanwhile"
            };
            Patent patent1 = new Patent()
            {
                Country = "Countrytest1",
                RegistrationNumber = 1211612821,
                PublicationDate = new System.DateTime(1936, 1, 6),
                DateOfApplication = new System.DateTime(1996, 1, 4),
                NumberOfPages = 102,
                Annotation = "Annotation1",
                Title = "TestPatentTitle1"
            };
            author.Id = _authorLogic.AddAuthor(author);
            _patentLogic.AddPatent(patent, author.Id);

            Assert.IsNotEmpty(_patentLogic.GetAllPatent());
        }

        /*
        [Test]
        public void EditPatent()
        {
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            Patent patent = new Patent()
            {
                Id = TestingIdVariable,
                Country = "Countrytest",
                RegistrationNumber = 121823821,
                PublicationDate = new System.DateTime(1933, 5, 6),
                DateOfApplication = new System.DateTime(1993, 5, 6),
                NumberOfPages = 122,
                Annotation = "Annotation That is edited",
                Title = "TestPatentTitle"
            };
            _patentLogic.EditPatent(patent);
            _patentLogic.GetPatentById(TestingIdVariable);
        }
        */

        [Test]
        public void DeletePatent()
        {
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            _patentLogic.DeletePatentById(TestingIdVariable);
        }
    }
}