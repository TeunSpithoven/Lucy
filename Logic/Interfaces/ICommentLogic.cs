using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICommentLogic
    {
        public List<CommentLogicModel> GetAll();
        public List<CommentLogicModel> GetByUserId(int userId);
        public CommentLogicModel GetById(int id);
        public List<CommentLogicModel> GetByDreamId(int dreamId);
        public CommentLogicModel Create(string message, int userId, int dreamId);
    }
}
