using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Test.Data
{
    public class CommentTestData : ICommentData
    {
        public static List<CommentDataModel> Items;
        private static int _id;
        public List<CommentDataModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CommentDataModel> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public CommentDataModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentDataModel> GetByDreamId(int dreamId)
        {
            throw new NotImplementedException();
        }

        public CommentDataModel Create(CommentDataModel dataComment)
        {
            throw new NotImplementedException();
        }
    }
}
