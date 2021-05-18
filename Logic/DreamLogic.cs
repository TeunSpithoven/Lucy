using System.Collections.Generic;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;

namespace Logic
{
    public class DreamLogic : IDreamLogic
    {
        private readonly IDreamData DreamData;
        public DreamLogic(IDreamData dreamConnector)
        {
            DreamData = dreamConnector;
        }

        public void AddDream(DreamLogicModel logicDream)
        {
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamData.AddDream(conDream);
        }

        public void RemoveDream(int id)
        {
            DreamData.RemoveDreamById(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            List<DreamConnectorModel> conDreams = DreamData.GetDreams();
            List<DreamLogicModel> logicDreams = new();
            foreach (var conDream in conDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.ConnectorToLogicDreamModel(conDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public List<DreamLogicModel> GetDreamsByUserId(int userId)
        {
            List<DreamConnectorModel> conDreams = DreamData.GetDreamsByUserId(userId);
            List<DreamLogicModel> logicDreams = new();
            foreach (var conDream in conDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.ConnectorToLogicDreamModel(conDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public DreamLogicModel GetDreamById(int id)
        {
            DreamConnectorModel conDream = DreamData.GetDreamById(id);
            DreamLogicModel logicDream = DreamLogicMapper.ConnectorToLogicDreamModel(conDream);
            return logicDream;
        }
    }
}
