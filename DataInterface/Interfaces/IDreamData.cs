using System.Collections.Generic;
using DataInterface.Models;

namespace DataInterface.Interfaces
{
    public interface IDreamData
    {
        public DreamDataModel AddDream(DreamDataModel dataDream);
        public int RemoveDreamById(int id);
        public List<DreamDataModel> GetDreams();
        public List<DreamDataModel> GetDreamsByUserId(int userId);
        public DreamDataModel GetDreamById(int id);
    }
}
