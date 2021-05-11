using System.Collections.Generic;
using Data.Factories;
using Data.Interfaces;
using Data.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class DreamLogic : IDreamLogic
    {
        public IDreamData DreamData;
        public DreamLogic(IDreamData dreamData)
        {
            DreamData = dreamData;
        }

        public void AddDream(DreamLogicModel logicDream)
        {
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamData.AddDream(dataDream);
        }

        public void RemoveDream(int id)
        {
            DreamData.RemoveDreamById(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            List<DreamDataModel> dataDreams = DreamData.GetDreams();
            List<DreamLogicModel> logicDreams = new();
            foreach (var dataDream in dataDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.DataToLogicDreamModel(dataDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public List<DreamLogicModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> dataDreams = DreamData.GetDreamsByUserId(userId);
            List<DreamLogicModel> logicDreams = new();
            foreach (var dataDream in dataDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.DataToLogicDreamModel(dataDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public DreamLogicModel GetDreamById(int id)
        {
            DreamDataModel dataDream = DreamData.GetDreamById(id);
            DreamLogicModel logicDream = DreamLogicMapper.DataToLogicDreamModel(dataDream);
            return logicDream;
        }
    }
}
