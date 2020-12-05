using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces
{
    public interface IPatentLogic
    {
        Patent GetPatentById(int id);

        IEnumerable<Patent> GetAllPatent();

        int AddPatent(Patent patent, int authorId);

        void DeletePatentById(int id);

        void EditPatent(Patent patent, int authorId);
    }
}