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
    public class AuthorLogic : IAuthorLogic
    {
        private IAuthorDao _authorDao;

        public AuthorLogic(IAuthorDao authorDao)
        {
            _authorDao = authorDao;
        }

        public int AddAuthor(Author author)
        {
            AuthorValidation validation = new AuthorValidation(author);
            validation.FirstNameIsValid = validation.AuthorFirstNameValidation();
            validation.LastNameIsValid = validation.AuthorLastNameValidation();
            if (!validation.exceptionList.Any())
            {
                return _authorDao.AddAuthor(author);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in validation.exceptionList)
                {
                    sb.Append(item + Environment.NewLine);
                }
                throw new AuthorValidationException(sb.ToString());
            }
        }

        public void DeleteAuthor(int authorId)
        {
            _authorDao.DeleteAuthor(authorId);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorDao.GetAllAuthors();
        }

        public IEnumerable<Book> GetBooksByAuthorId(int idAuthor)
        {
            return _authorDao.GetBooksByAuthorId(idAuthor);
        }

        public Author GetAuthorById(int idAuthor)
        {
            return _authorDao.GetAuthorById(idAuthor);
        }

        public IEnumerable<PrintEdition> GetPatentsAndBooksByAuthorId(int idAuthor) 
        {
            return _authorDao.GetPatentsAndBooksByAuthorId(idAuthor);
        }

        public IEnumerable<Patent> GetPatentsByAuthorId(int idAuthor)
        {
            return _authorDao.GetPatentsByAuthorId(idAuthor);
        }

        public IEnumerable<Author> GetAuthorByBookId(int bookId)
        {
            return _authorDao.GetAuthorByBookId(bookId);
        }

        public IEnumerable<Author> GetAuthorByPatentId(int patentId)
        {
            return _authorDao.GetAuthorByPatentId(patentId);
        }

        public void EditAuthor(Author author)
        {
            _authorDao.EditAuthor(author);
        }

        public List<int> GetAuthorsIdsByBookid(int bookId)
        {
            return _authorDao.GetAuthorsIdsByBookId(bookId);
        }

        public List<SelectListSerialization> GetAuthorsBySearchTextForList(string searchText)
        {
            List<SelectListSerialization> authors = new List<SelectListSerialization>();
            foreach (var item in _authorDao.GetAuthorsBySearchTextForList(searchText))
            {
                authors.Add(new SelectListSerialization(item.Id, $"{item.FirstName }{item.LastName }"));
            }
            return authors;
        }

        public List<SelectListSerialization> GetAuthorsByIdForListForBook(int id)
        {
            List<SelectListSerialization> authors = new List<SelectListSerialization>();
            foreach (var item in _authorDao.GetAuthorsByIdForListForBook(id))
            {
                authors.Add(new SelectListSerialization(item.Id, $"{item.FirstName }{item.LastName }"));
            }
            return authors;
        }

        public List<SelectListSerialization> GetAuthorsByIdForListForPatent(int patentId)
        {
            List<SelectListSerialization> authors = new List<SelectListSerialization>();
            foreach (var item in _authorDao.GetAuthorsByIdForListForPatent(patentId))
            {
                authors.Add(new SelectListSerialization(item.Id, $"{item.FirstName }{item.LastName }"));
            }
            return authors;
        }
    }
}