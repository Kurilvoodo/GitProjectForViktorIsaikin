using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL
{
    public class NewspaperIssueLogic : INewspaperIssueLogic
    {
        private INewspaperIssueDao _newspaperIssueDao;

        public NewspaperIssueLogic(INewspaperIssueDao newspaperIssueDao)
        {
            _newspaperIssueDao = newspaperIssueDao;
        }

        public int AddNewspaperIssue(NewspaperIssue newspaperIssue, int newspaperId)
        {
            return _newspaperIssueDao.AddNewspaperIssue(newspaperIssue, newspaperId);
        }

        public void DeleteNewspaperIssue(int newspaperIssueId)
        {
            _newspaperIssueDao.DeleteNewspaperIssue(newspaperIssueId);
        }

        public void EditNewspaperIssue(NewspaperIssue newspaperIssue)
        {
            _newspaperIssueDao.EditNewspaperIssue(newspaperIssue);
        }

        public IEnumerable<NewspaperIssue> GetAllNewspaperIssuesByNewspaperId(int newspaperId)
        {
            return _newspaperIssueDao.GetAllNewspaperIssuesByNewspaperId(newspaperId);
        }

        public NewspaperIssue GetNewspaperIssueById(int id)
        {
            return _newspaperIssueDao.GetNewspaperIssueById(id);
        }
    }
}