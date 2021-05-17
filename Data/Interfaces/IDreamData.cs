using System.Collections.Generic;
using Data.Models;

namespace LogicDataConnector.Interfaces
{
    public interface IDreamData
    {
        public void AddDream(DreamDataModel dataDream);
        public void RemoveDreamById(int id);
        public List<DreamDataModel> GetDreams();
        public List<DreamDataModel> GetDreamsByUserId(int userId);
        public DreamDataModel GetDreamById(int id);
    }
}
