using Exceptions;
using Ninject;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Ioc;
using System;
using System.Data.SqlClient;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.Info("Aplcation Started");
            var _authorLogic = NinjaDependencryResolver.Kernel.Get<IAuthorLogic>();
            var _bookLogic = NinjaDependencryResolver.Kernel.Get<IBookLogic>();
            var _patentLogic = NinjaDependencryResolver.Kernel.Get<IPatentLogic>();
            var _newspaperLogic = NinjaDependencryResolver.Kernel.Get<INewspaperLogic>();
            var _printEditionLogic = NinjaDependencryResolver.Kernel.Get<IPrintEditionLogic>();
            var _newspaperIssueLogic = NinjaDependencryResolver.Kernel.Get<INewspaperIssueLogic>();
            Author testAuthor = new Author()
            {
                FirstName = "Testalex",
                LastName = "Testzavalni"
            };
            Author testAuthor1 = new Author()
            {
                FirstName = "Testalex",
                LastName = "Testaavalni"
            };
            Book testBook = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-1423-1645-X",
                NumberOfPages = 15,
                PlaceOfPublication = "Place",
                PublicationYear = 1997,
                PublishingHouse = "House",
                Title = "Title"
            };
            Book testBook1 = new Book()
            {
                Annotation = "Annotation",
                ISBN = "ISBN 7-4145-1875-X",
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
            int authorId = 0;
            Logger.Info($"Trying to add to database Author: {testAuthor}" + Environment.NewLine +
                $"His Book {testBook}" + Environment.NewLine +
                $"His patent {testPatent}" + Environment.NewLine);
            try
            {
                try
                {
                    authorId = _authorLogic.AddAuthor(testAuthor);
                }
                catch (AuthorValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
                try
                {
                    _bookLogic.AddBook(testBook, authorId);
                }
                catch (BookValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
                try
                {
                    _patentLogic.AddPatent(testPatent, authorId);
                }
                catch (PatentValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
            }
            catch (SqlException ex)
            {
                Logger.Error("Database Error" + ex.Message);
                Console.WriteLine("Database Error");
            }
            Logger.Info("Operation ended");
            int author1Id = 0;
            Logger.Info($"Trying to add to database Author: {testAuthor}" + Environment.NewLine +
                $"His Book {testBook}" + Environment.NewLine +
                $"His patent {testPatent}" + Environment.NewLine);
            try
            {
                try
                {
                    author1Id = _authorLogic.AddAuthor(testAuthor1);
                }
                catch (AuthorValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
                try
                {
                    _bookLogic.AddBook(testBook1, author1Id);
                }
                catch (BookValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
                try
                {
                    _patentLogic.AddPatent(testPatent1, author1Id);
                }
                catch (PatentValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you've using is in incorrect form: " +
                        ex.Message);
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Database Error");
            }
            Logger.Info("Operation ended");

            Logger.Info($"Get Patents and Books By Author Id {authorId}");
            Console.WriteLine($"Get Patents and Books By Author Id {authorId}");
            try
            {
                foreach (var item in _authorLogic.GetPatentsAndBooksByAuthorId(authorId))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (SqlException ex)
            {
                Logger.Error("Database Error" + ex.Message);
                Console.WriteLine("Database Error occured");
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database  is in incorrect form: " +
                    ex.Message);
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            Logger.Info("Operation ended");

            Logger.Info($"Get Patents and books by author Id: {author1Id}");
            Console.WriteLine($"Get Patents and Books By Author Id {author1Id}");
            try
            {
                foreach (var item in _authorLogic.GetPatentsAndBooksByAuthorId(author1Id))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (SqlException ex)
            {
                Logger.Error("Database Error " + ex.Message);
                Console.WriteLine("Database Error occured");
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            Logger.Info("Operation ended");

            Logger.Info($"Get Books By Author Id {authorId}");
            Console.WriteLine($"Get Books by Author Id {authorId}");
            try
            {
                foreach (var item in _authorLogic.GetBooksByAuthorId(authorId))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Database error occrued");
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            Logger.Info("Operation ended");

            Logger.Info($"Get Patents by AuthorId {author1Id}");
            Console.WriteLine($"Get Patents by Author Id {author1Id}");
            try
            {
                foreach (var item in _authorLogic.GetPatentsByAuthorId(author1Id))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Database error occrued");
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            Logger.Info("Operation ended");
            Newspaper newspaper = new Newspaper()
            {
                Annotation = "Annotation",
                ISSN = "ISSN 1422-1215",
                PlaceOfPublication = "Saratov",
                Title = "Murzilka",
                PublicationYear = 1995,
                PublishingHouse = "SomeKindOfHouse"
            };
            Logger.Info($"Trying to add new newspaper to databse: {newspaper}");
            int newspaperId = 0;
            try
            {
                try
                {
                    newspaperId = _newspaperLogic.AddNewspaper(newspaper);
                }
                catch (NewspaperValidationException ex)
                {
                    Logger.Error(ex.Message);
                    Console.WriteLine("Validation error: Data you're using is in incorrect form: " +
                        ex.Message);
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Database error occured");
            }
            Logger.Info("Operation ended");
            Logger.Info("Trying to make a NewspaperIssue");
            NewspaperIssue newspaperIssue = new NewspaperIssue()
            {
                NewspaperId = newspaperId,
                ReleaseNumber = 1,
                ReleaseDate = DateTime.Now,
                NumberOfPages = 15
            };
            NewspaperIssue newspaperIssue2 = new NewspaperIssue()
            {
                NewspaperId = newspaperId,
                ReleaseNumber = 2,
                ReleaseDate = DateTime.Now,
                NumberOfPages = 19
            };
            int testingIssueId1 = _newspaperIssueLogic.AddNewspaperIssue(newspaperIssue, newspaperIssue.NewspaperId);
            int testingIssueId2 = _newspaperIssueLogic.AddNewspaperIssue(newspaperIssue2, newspaperIssue2.NewspaperId);
            Console.WriteLine("____________________________");
            Console.WriteLine(_newspaperIssueLogic.GetNewspaperIssueById(testingIssueId1).ToString() + Environment.NewLine);
            Console.WriteLine(_newspaperIssueLogic.GetNewspaperIssueById(testingIssueId2).ToString() + Environment.NewLine);
            Console.WriteLine("Test the GetAllNewspaperIssuesByNewspaperId method ");
            foreach (var item in _newspaperIssueLogic.GetAllNewspaperIssuesByNewspaperId(newspaperId))
            {
                Console.WriteLine(item.ToString());
            }
            Logger.Info("Operation ended");

            Logger.Info("Trying to get all Books Patents and Newspapers");
            try
            {
                foreach (var item in _printEditionLogic.GetAllPrintEditions())
                {
                    item.ToString();
                }
            }
            catch (SqlException ex)
            {
                Logger.Info($"Database error occured: {ex.Message}");
                Console.WriteLine("Database error occured");
            }
            catch (NewspaperValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database  in incorrect form: " +
                    ex.Message);
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            Logger.Info("Operation ended");

            Logger.Info("trying to get all books and patents and newspapers grouped by Publication Year Descending");
            try
            {
                foreach (var item in _printEditionLogic.GetAllPrintEditionsSortedByPublicationYearDescending())
                {
                    Console.WriteLine($"{item}");
                }
            }
            catch (SqlException ex)
            {
                Logger.Info($"Database error occured: {ex.Message}");
                Console.WriteLine("Database error occured");
            }
            catch (NewspaperValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database  in incorrect form: " +
                    ex.Message);
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }

            Logger.Info("trying to get all books and patents and newspapers grouped by Publication Year");
            try
            {
                foreach (var item in _printEditionLogic.GetAllPrintEditionsSortedByPublicationYear())
                {
                    Console.WriteLine($"{item}");
                }
            }
            catch (SqlException ex)
            {
                Logger.Info($"Database error occured: {ex.Message}");
                Console.WriteLine("Database error occured");
            }
            catch (NewspaperValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }
            catch (PatentValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database  in incorrect form: " +
                    ex.Message);
            }
            catch (BookValidationException ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine("Validation error: Data coming from database is in incorrect form: " +
                    ex.Message);
            }

            Logger.Info("Program has end his process");
            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}