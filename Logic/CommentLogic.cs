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
            //gets all comments from data source
            List<CommentLogicModel> logicComments = new();
            List<CommentDataModel> dataComments = _commentData.GetAll();
            foreach(CommentDataModel dataComment in dataComments)
                logicComments.Add(CommentLogicMapper.DataToLogicCommentModel(dataComment));
            return logicComments;
        }

        public List<CommentLogicModel> GetByUserId(int userId)
        {
            //gets all comments from data source where userId is the given userId
            if(userId < 1)
            {
                throw new ValidationException("Validation for Commentlogic GetByUserId failed.");
            }
            List<CommentDataModel> dataList = _commentData.GetByUserId(userId);
            List<CommentLogicModel> returnList = new();
            foreach (CommentDataModel dataComment in dataList)
            {
                returnList.Add(CommentLogicMapper.DataToLogicCommentModel(dataComment));
            }
            return returnList;
        }

        public CommentLogicModel GetById(int id)
        {
            //gets the comment from data source where id = given id
            if (id < 1)
            {
                throw new ValidationException("Validation for Commentlogic GetById failed.");
            }
            CommentDataModel dataComment = _commentData.GetById(id);
            return CommentLogicMapper.DataToLogicCommentModel(dataComment);
        }

        public List<CommentLogicModel> GetByDreamId(int dreamId)
        {
            //gets all comments where dreamId = given dreamId
            if (dreamId < 1)
            {
                throw new ValidationException("Validation for Commentlogic GetByDreamId failed.");
            }
            List<CommentDataModel> dataList = _commentData.GetByUserId(dreamId);
            List<CommentLogicModel> returnList = new();
            foreach (CommentDataModel dataComment in dataList)
            {
                returnList.Add(CommentLogicMapper.DataToLogicCommentModel(dataComment));
            }
            return returnList;
        }

        public CommentLogicModel Create(int userId, string message, int dreamId)
        {
            //creates a new comment and saves it
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
