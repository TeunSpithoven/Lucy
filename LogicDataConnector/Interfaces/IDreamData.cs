using System.Collections.Generic;
using LogicDataConnector.Models;

namespace LogicDataConnector.Interfaces
{
    public interface IDreamData
    {
        public void AddDream(DreamConnectorModel dataDream);
        public void RemoveDreamById(int id);
        public List<DreamConnectorModel> GetDreams();
        public List<DreamConnectorModel> GetDreamsByUserId(int userId);
        public DreamConnectorModel GetDreamById(int id);
    }
}
