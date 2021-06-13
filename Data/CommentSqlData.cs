using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.Interfaces;
using DataInterface.Models;
using Microsoft.Data.SqlClient;

namespace Data.SqlData
{
    public class CommentSqlData : ICommentData
    {
        public List<CommentDataModel> GetAll()
        {
            List<CommentDataModel> dataComments = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("SELECT * FROM Comment", conn);
            
            conn.Open();
            var reader = query.ExecuteReader();

            if (!reader.HasRows) return dataComments;
            while (reader.Read())
                dataComments.Add(new CommentDataModel(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["UserId"]), Convert.ToString(reader["Message"]), Convert.ToInt32(reader["DreamId"])));
            return dataComments;
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
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"INSERT INTO Comment (UserId, Message, DreamId) OUTPUT INSERTED.ID VALUES (@UserId, @Message, @DreamId)", conn);

            query.Parameters.AddWithValue("@UserId", dataComment.UserId);
            query.Parameters.AddWithValue("@Message", dataComment.Message);
            query.Parameters.AddWithValue("@DreamId", dataComment.DreamId);

            conn.Open();
            int newId = (int)query.ExecuteScalar();

            return new(newId, dataComment.UserId, dataComment.Message, dataComment.DreamId);
        }
    }
}
