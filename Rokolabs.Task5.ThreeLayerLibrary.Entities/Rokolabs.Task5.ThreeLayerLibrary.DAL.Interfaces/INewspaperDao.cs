using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface INewspaperDao
    {
        Newspaper GetNewspaperById(int id);

        IEnumerable<Newspaper> GetAllNewspapers();

        int AddNewspaper(Newspaper newspaper);

        void DeleteNewspaperById(int id);

        void EditNewspaper(Newspaper newspaper);
    }
}