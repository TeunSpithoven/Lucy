using Logic.Models;
using View.Models;

namespace View.Mappers
{
    public static class CommentViewMapper
    {
        public static CommentViewModel LogicToViewCommentModel(CommentLogicModel l)
        {
            return new(l.Id, l.UserId, l.Message, l.DreamId);
        }
    }
}
