using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Data.Interfaces;
using Data.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class DreamLogic : IDreamLogic
    {
        private readonly IDreamData _dreamData;
        public DreamLogic(IDreamData dreamData)
        {
            _dreamData = dreamData;
        }

        public void AddDream(DreamLogicModel logicDream)
        {
            ValidationContext context = new(logicDream);
            IList<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(logicDream, context, errors);

            if (errors.Any()) return;

            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            _dreamData.AddDream(dataDream);
        }

        public void RemoveDream(int id)
        {
            _dreamData.RemoveDreamById(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            List<DreamDataModel> conDreams = _dreamData.GetDreams();
            List<DreamLogicModel> logicDreams = new();
            foreach (var conDream in conDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.DataToLogicDreamModel(conDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public List<DreamLogicModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> conDreams = _dreamData.GetDreamsByUserId(userId);
            List<DreamLogicModel> logicDreams = new();
            foreach (var conDream in conDreams)
            {
                DreamLogicModel newLogicDream = DreamLogicMapper.DataToLogicDreamModel(conDream);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public DreamLogicModel GetDreamById(int id)
        {
            DreamDataModel conDream = _dreamData.GetDreamById(id);
            DreamLogicModel logicDream = DreamLogicMapper.DataToLogicDreamModel(conDream);
            return logicDream;
        }
    }
}
