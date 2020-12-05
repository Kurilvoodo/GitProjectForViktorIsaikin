using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface INewspaperIssueDao
    {
        int AddNewspaperIssue(NewspaperIssue newspaperIssue, int newspaperId);

        void DeleteNewspaperIssue(int newspaperIssueId);

        IEnumerable<NewspaperIssue> GetAllNewspaperIssuesByNewspaperId(int newspaperId);

        NewspaperIssue GetNewspaperIssueById(int id);

        void EditNewspaperIssue(NewspaperIssue newspaperIssue);
    }
}