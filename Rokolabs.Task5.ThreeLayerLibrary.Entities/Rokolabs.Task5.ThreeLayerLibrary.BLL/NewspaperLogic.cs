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
    public class NewspaperLogic : INewspaperLogic
    {
        private INewspaperDao _newspaperDao;

        public NewspaperLogic(INewspaperDao newspaperDao)
        {
            _newspaperDao = newspaperDao;
        }

        public int AddNewspaper(Newspaper newspaper)
        {
            NewspaperValidation validation = new NewspaperValidation(newspaper);
            validation.ISSNIsValid = validation.ISSNValidation();
            validation.NewspaperGeneralValidation.ExecuteValidation();
            if (!validation.newspaperValidationExceptions.Any() &&
                !validation.NewspaperGeneralValidation.generalValidationExceptions.Any())
            {
                return _newspaperDao.AddNewspaper(newspaper);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (!validation.newspaperValidationExceptions.Any())
                {
                    foreach (var item in validation.newspaperValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }
                if (!validation.NewspaperGeneralValidation.generalValidationExceptions.Any())
                {
                    foreach (var item in validation.NewspaperGeneralValidation.generalValidationExceptions)
                    {
                        sb.Append(item + Environment.NewLine);
                    }
                }

                throw new NewspaperValidationException(sb.ToString());
            }
        }

        public void DeleteNewspaperById(int id)
        {
            _newspaperDao.DeleteNewspaperById(id);
        }

        public void EditNewspaper(Newspaper newspaper)
        {
            _newspaperDao.EditNewspaper(newspaper);
        }

        public IEnumerable<Newspaper> GetAllNewspapers()
        {
            return _newspaperDao.GetAllNewspapers();
        }

        public Newspaper GetNewspaperById(int id)
        {
            return _newspaperDao.GetNewspaperById(id);
        }
    }
}