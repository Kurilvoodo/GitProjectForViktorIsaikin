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
    public class PatentLogic : IPatentLogic
    {
        private IPatentDao _patentDao;

        public PatentLogic(IPatentDao patentDao)
        {
            _patentDao = patentDao;
        }

        public int AddPatent(Patent patent, int authorId)
        {
            if (authorId <= 0)
            {
                throw new AuthorValidationException($"Wrong Id:{authorId} - can't be 0 o below");
            }
            else
            {
                PatentValidation validation = new PatentValidation(patent);
                validation.ExecutePatentValidation();
                if (!validation.patentValidationExceptions.Any() &&
                    !validation.GeneralValidation.generalValidationExceptions.Any())
                {
                    return _patentDao.AddPatent(patent, authorId);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    if (!validation.patentValidationExceptions.Any())
                    {
                        foreach (var item in validation.patentValidationExceptions)
                        {
                            sb.Append(item + Environment.NewLine);
                        }
                    }
                    if (!validation.GeneralValidation.generalValidationExceptions.Any())
                    {
                        foreach (var item in validation.GeneralValidation.generalValidationExceptions)
                        {
                            sb.Append(item + Environment.NewLine);
                        }
                    }

                    throw new PatentValidationException(sb.ToString());
                }
            }
        }

        public void DeletePatentById(int id)
        {
            _patentDao.DeletePatentById(id);
        }

        public void EditPatent(Patent patent, int authorId)
        {
            _patentDao.EditPatent(patent, authorId);
        }

        public IEnumerable<Patent> GetAllPatent()
        {
            return _patentDao.GetAllPatent();
        }

        public Patent GetPatentById(int id)
        {
            return _patentDao.GetPatentById(id);
        }
    }
}