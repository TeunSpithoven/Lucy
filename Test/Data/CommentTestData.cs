using System;
using System.Collections.Generic;
using System.Linq;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Test.Data
{
    public class CommentTestData : ICommentData
    {
        public static List<CommentDataModel> Items = new();
        private static int _id;
        public List<CommentDataModel> GetAll()
        {
            return Items;
        }

        public List<CommentDataModel> GetByUserId(int userId)
        {
            return Items.Where(x => x.UserId == userId).ToList();
        }

        public CommentDataModel GetById(int id)
        {
            return Items.Find(x => x.Id == id);
        }

        public List<CommentDataModel> GetByDreamId(int dreamId)
        {
            return Items.Where(x => x.DreamId == dreamId).ToList();
        }

        public CommentDataModel AddComment(CommentDataModel dataComment)
        {
            dataComment.Id = _id;
            _id++;
            Items.Add(dataComment);
            return dataComment;
        }
    }
}
