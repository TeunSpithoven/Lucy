using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataInterface.Interfaces;
using DataInterface.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentData _commentData;
        public CommentLogic(ICommentData commentData)
        {
            _commentData = commentData;
        }

        public List<CommentLogicModel> GetAll()
        {
            List<CommentLogicModel> logicComments = new();
            List<CommentDataModel> dataComments = _commentData.GetAll();
            foreach(CommentDataModel dataComment in dataComments)
                logicComments.Add(CommentLogicMapper.DataToLogicCommentModel(dataComment));
            return logicComments;
        }

        public List<CommentLogicModel> GetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public CommentLogicModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CommentLogicModel> GetByDreamId(int dreamId)
        {
            throw new System.NotImplementedException();
        }

        public CommentLogicModel Create(int userId, string message, int dreamId)
        {
            if (userId < 1 || dreamId < 1)
            {
                throw new ValidationException("CommentLogic Create validation failed");
            }
            CommentDataModel dataComment = CommentLogicMapper.LogicToDataCommentModel(new CommentLogicModel(userId, message, dreamId));
            CommentDataModel returnComment = _commentData.AddComment(dataComment);
            return CommentLogicMapper.DataToLogicCommentModel(returnComment);
        }
    }
}
