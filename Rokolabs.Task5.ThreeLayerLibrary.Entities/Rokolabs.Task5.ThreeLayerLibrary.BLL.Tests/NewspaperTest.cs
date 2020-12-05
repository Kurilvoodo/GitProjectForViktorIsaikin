using Ninject;
using NUnit.Framework;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Ioc;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Tests
{
    [TestFixture]
    public class NewspaperTest
    {
        public static int TestingIdVariable = 1;

        [Test]
        public void AddNewspaperTest()
        {
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            Newspaper newspaper = new Newspaper()
            {
                Annotation = "Annotation",
                ISSN = "ISSN 1422-1215",
                PlaceOfPublication = "Somewhere",
                Title = "Test",
                PublicationYear = 1995,
                PublishingHouse = "SomeKindOfHouse"
            };
            TestingIdVariable = _newspaperLogic.AddNewspaper(newspaper);
            Assert.IsNotNull(TestingIdVariable);
        }

        [Test]
        public void GetNewspaperByIdTest()
        {
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            _newspaperLogic.GetNewspaperById(TestingIdVariable);
        }

        [Test]
        public void GetAllNewspapers()
        {
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            Newspaper newspaper = new Newspaper()
            {
                Annotation = "Annotation",
                ISSN = "ISSN 1242-1215",
                PlaceOfPublication = "Somewhere",
                Title = "Test",
                PublicationYear = 1995,
                PublishingHouse = "SomeKindOfHouse"
            };
            _newspaperLogic.AddNewspaper(newspaper);
            Newspaper newspaper1 = new Newspaper()
            {
                Annotation = "Annotation",
                ISSN = "ISSN 2141-1885",
                PlaceOfPublication = "Somewhere1",
                Title = "Test1",
                PublicationYear = 1998,
                PublishingHouse = "SomeKindOfHouse1"
            };
            _newspaperLogic.AddNewspaper(newspaper1);
            Assert.IsNotEmpty(_newspaperLogic.GetAllNewspapers());
        }

        /*
        [Test]
        public void EditNewspaperTest()
        {
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            Newspaper newspaperForEditing = new Newspaper()
            {
                Id = TestingIdVariable,
                Annotation = "Annotation",
                NumberOfPages = 15,
                PlaceOfPublication = "Somewhere that edit",
                Title = "Test",
                PublicationYear = 1995,
                PublishingHouse = "SomeKindOfHouseThatEdit"
            };
            _newspaperLogic.EditNewspaper(newspaperForEditing);
            _newspaperLogic.GetNewspaperById(TestingIdVariable);
        }*/

        [Test]
        public void DeleteNewspaperByIdTest()
        {
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            _newspaperLogic.DeleteNewspaperById(TestingIdVariable);
        }
    }
}