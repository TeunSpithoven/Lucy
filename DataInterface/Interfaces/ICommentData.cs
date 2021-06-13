using System.Collections.Generic;
using DataInterface.Models;

namespace DataInterface.Interfaces
{
    public interface ICommentData
    {
        public List<CommentDataModel> GetAll();
        public List<CommentDataModel> GetByUserId(int userId);
        public CommentDataModel GetById(int id);
        public List<CommentDataModel> GetByDreamId(int dreamId);
        public CommentDataModel Create(CommentDataModel dataComment);
    }
}
