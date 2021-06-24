using DataInterface.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class CommentLogicMapper
    {
        public static CommentLogicModel DataToLogicCommentModel(CommentDataModel d)
        {
            return new(d.Id, d.UserId, d.Message, d.DreamId);
        }

        public static CommentDataModel LogicToDataCommentModel(CommentLogicModel l)
        {
            return new(l.Id, l.UserId, l.Message, l.DreamId);
        }
    }
}
