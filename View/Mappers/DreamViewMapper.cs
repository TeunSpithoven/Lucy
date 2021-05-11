using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;
using Objects;
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
