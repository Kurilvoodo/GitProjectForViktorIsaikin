using Exceptions;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL
{
    public class BookLogic : IBookLogic
    {
        private IBookDao _bookDao;

        public BookLogic(IBookDao bookDao)
        {
            _bookDao = bookDao;
        }

        public int AddBook(Book book, int authorId)
        {
            BookValidation validation = new BookValidation(book);
            validation.ExecuteBookValidation();
            if (!validation.bookValidationExceptions.Any() &&
                !validation.BookGeneralValidation.generalValidationExceptions.Any())
            {
                return _bookDao.AddBook(book, authorId);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (!validation.bookValidationExceptions.Any())
                {
                    foreach (var item in validation.bookValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }
                if (!validation.BookGeneralValidation.generalValidationExceptions.Any())
                {
                    foreach (var item in validation.BookGeneralValidation.generalValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }
                throw new BookValidationException(sb.ToString());
            }
        }

        public void DeleteBookById(int id)
        {
            _bookDao.DeleteBookById(id);
        }

        public void EditBook(Book book, int authorId)
        {
            BookValidation validation = new BookValidation(book);
            validation.BookGeneralValidation.ExecuteValidation();
            if (!validation.bookValidationExceptions.Any() &&
                !validation.BookGeneralValidation.generalValidationExceptions.Any())
            {
                _bookDao.EditBook(book, authorId);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (!validation.bookValidationExceptions.Any())
                {
                    foreach (var item in validation.bookValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }
                if (!validation.BookGeneralValidation.generalValidationExceptions.Any())
                {
                    foreach (var item in validation.BookGeneralValidation.generalValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }

                throw new BookValidationException(sb.ToString());
            }
        }

        public ILookup<string, Book> FindAllBooksByPublishingHouse(string partPublishingHouseName)
        {
            return _bookDao.FindAllBooksByPublishingHouse(partPublishingHouseName);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDao.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookDao.GetBookById(id);
        }
    }
}