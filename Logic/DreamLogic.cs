using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;

namespace Logic
{
    public class DreamLogic : IDreamLogic
    {
        private readonly IDreamData _dreamData;
        public DreamLogic(IDreamData dreamConnector)
        {
            _dreamData = dreamConnector;
        }

        public void AddDream(DreamLogicModel logicDream)
        {
            ValidationContext context = new(logicDream);
            IList<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(logicDream, context, errors);

            if (errors.Any()) return;

            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            _dreamData.AddDream(conDream);
        }

        public void RemoveDream(int id)
        {
            _dreamData.RemoveDreamById(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            List<DreamConnectorModel> conDreams = _dreamData.GetDreams();
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
            List<DreamConnectorModel> conDreams = _dreamData.GetDreamsByUserId(userId);
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
            DreamConnectorModel conDream = _dreamData.GetDreamById(id);
            DreamLogicModel logicDream = DreamLogicMapper.ConnectorToLogicDreamModel(conDream);
            return logicDream;
        }
    }
}
