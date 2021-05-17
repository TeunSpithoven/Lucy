using Logic.Models;
using LogicDataConnector.Models;

namespace Logic.Mappers
{
    public static class DreamLogicMapper
    {
        public static DreamConnectorModel LogicToConnectorDreamModel(DreamLogicModel logicDream)
        {
            DreamConnectorModel conDream;
            conDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
            return conDream;
        }

        public static DreamLogicModel ConnectorToLogicDreamModel(DreamConnectorModel conDream)
        {
            DreamLogicModel logicDream;
            logicDream = new DreamLogicModel(conDream.Id, conDream.UserId, conDream.Title, conDream.Story, conDream.CreationDateTime);
            return logicDream;
        }
    }
}
