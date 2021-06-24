using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataInterface.Interfaces;
using DataInterface.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class DreamLogic : IDreamLogic
    {
        private readonly IDreamData _dreamData;
        private readonly ICommentData _commentData;
        public DreamLogic(IDreamData dreamData, ICommentData commentData)
        {
            _dreamData = dreamData;
            _commentData = commentData;
        }

        public DreamLogicModel Create(int userId, string title, string story)
        {
            DreamLogicModel logicDream = new(userId, title, story);
            ValidationContext context = new(logicDream);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(logicDream, context, errors))
            {
                throw new ValidationException("DreamLogic Create validation failed");
            }

            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamDataModel addedDream = _dreamData.AddDream(dataDream);
            return DreamLogicMapper.DataToLogicDreamModel(addedDream);
        }

        public int RemoveDream(int id)
        {
            ValidationContext context = new ValidationContext(new DreamLogicModel()) { MemberName = "Id" };
            IList<ValidationResult> errors = new List<ValidationResult>();
            
            if (!Validator.TryValidateProperty(id, context, errors))
            {
                throw new ValidationException("DreamLogic RemoveDream validation failed");
            }
            return _dreamData.RemoveDreamById(id);
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
            ValidationContext context = new ValidationContext(new DreamLogicModel()) { MemberName = "UserId" };
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(userId, context, errors))
            {
                throw new ValidationException("DreamLogic GetDreamsByUserId validation failed");
            }
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
            // this test should test for an exception!
            ValidationContext context = new ValidationContext(new DreamLogicModel()) {MemberName = "Id"};
            IList<ValidationResult> errors = new List<ValidationResult>();
            
            if (!Validator.TryValidateProperty(id, context, errors))
            {
                throw new ValidationException("DreamLogic GetDreamsByUserId validation failed");
            }
            DreamDataModel dataDream = _dreamData.GetDreamById(id);
            if (dataDream == null) return null;
            dataDream.Comments = _commentData.GetByDreamId(id);
            DreamLogicModel returnDream = DreamLogicMapper.DataToLogicDreamModel(dataDream);
            return returnDream;
        }
    }
}
