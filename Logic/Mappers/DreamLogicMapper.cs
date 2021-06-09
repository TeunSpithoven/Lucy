using DataInterface.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class DreamLogicMapper
    {
        public static DreamDataModel LogicToDataDreamModel(DreamLogicModel logicDream)
        {
            if (logicDream == null) return null;
            return new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
        }

        public static DreamLogicModel DataToLogicDreamModel(DreamDataModel dataDream)
        {
            if (dataDream == null) return null;
            return new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime);
        }
    }
}
