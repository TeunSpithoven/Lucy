using System.Collections.Generic;
using Logic.Mappers;
using Logic.Models;
using View.Models;

namespace View.Mappers
{
    public static class DreamViewMapper
    {
        public static DreamViewModel LogicToViewDreamModel(DreamLogicModel logicDream)
        {
            List<CommentViewModel> viewComments = new();
            foreach (var comment in logicDream.Comments)
            {
                viewComments.Add(CommentViewMapper.LogicToViewCommentModel(comment));
            }
            DreamViewModel viewDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime, viewComments);
            return viewDream;
        }
    }
}
