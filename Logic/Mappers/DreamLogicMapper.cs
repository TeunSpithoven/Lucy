using Logic.Models;
using LogicDataConnector.Models;

namespace Logic.Mappers
{
    public static class DreamLogicMapper
    {
        public static DreamConnectorModel LogicToConnectorDreamModel(DreamLogicModel logicDream)
        {
            if (logicDream == null) return null;
            return new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
        }

        public static DreamLogicModel ConnectorToLogicDreamModel(DreamConnectorModel conDream)
        {
            if (conDream == null) return null;
            return new(conDream.Id, conDream.UserId, conDream.Title, conDream.Story, conDream.CreationDateTime);
        }
    }
}
