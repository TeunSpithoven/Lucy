using Logic.Models;
using View.Models;

namespace View.Mappers
{
    public static class DreamViewMapper
    {
        public static DreamViewModel LogicToViewDreamModel(DreamLogicModel logicDream)
        {
            DreamViewModel viewDream;
            viewDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
            return viewDream;
        }
    }
}
