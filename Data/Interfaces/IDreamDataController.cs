using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDreamDataController
    {
        public void AddDreamToDB(DreamDataModel logicDream);
        public void RemoveDreamByIdFromDB(int id);
        public List<DreamDataModel> GetDreamsFromDB();
        public List<DreamDataModel> GetDreamsByUserIdFromDB(int userId);
        public DreamDataModel GetDreamById(int id);
    }
}
