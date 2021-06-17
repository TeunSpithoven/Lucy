using System.Collections.Generic;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICommentLogic
    {
        public List<CommentLogicModel> GetAll();
        public List<CommentLogicModel> GetByUserId(int userId);
        public CommentLogicModel GetById(int id);
        public List<CommentLogicModel> GetByDreamId(int dreamId);
        public CommentLogicModel Create(int userId, string message, int dreamId);
    }
}
