using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class DreamLogicMapper
    {
        public static DreamDataModel LogicToDataDreamModel(DreamLogicModel logicDream)
        {
            DreamDataModel dataDream;
            dataDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
            return dataDream;
        }

        public static DreamLogicModel DataToLogicDreamModel(DreamDataModel dataDream)
        {
            DreamLogicModel logicDream;
            logicDream = new DreamLogicModel(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime);
            return logicDream;
        }
    }
}
