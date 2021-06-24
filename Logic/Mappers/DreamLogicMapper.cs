using DataInterface.Models;
using Logic.Models;
using System.Collections.Generic;

namespace Logic.Mappers
{
    public static class DreamLogicMapper
    {
        public static DreamDataModel LogicToDataDreamModel(DreamLogicModel logicDream)
        {
            if (logicDream == null) return null;
            List<CommentDataModel> dataComments = new();
            if (logicDream.Comments != null)
            {
                foreach (var comment in logicDream.Comments)
                {
                    dataComments.Add(CommentLogicMapper.LogicToDataCommentModel(comment));
                }
                return new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime, dataComments);
            }
            return new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime, new List<CommentDataModel>());
        }

        public static DreamLogicModel DataToLogicDreamModel(DreamDataModel dataDream)
        {
            if (dataDream == null) return null;
            List<CommentLogicModel> logicComments = new();
            if (dataDream.Comments != null)
            {
                foreach (var comment in dataDream.Comments)
                {
                    logicComments.Add(CommentLogicMapper.DataToLogicCommentModel(comment));
                }
                return new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime, logicComments);
            }

            return new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime, new List<CommentLogicModel>());
        }
    }
}