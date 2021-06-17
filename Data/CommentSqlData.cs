using System;
using System.Collections.Generic;
using DataInterface.Interfaces;
using DataInterface.Models;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class CommentSqlData : ICommentData
    {
        public List<CommentDataModel> GetAll()
        {
            List<CommentDataModel> dataComments = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("SELECT * FROM Comment", conn);

            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("CommentSqlData GetAll failed.");
            }
            

            if (!reader.HasRows) return dataComments;
            while (reader.Read())
                dataComments.Add(new CommentDataModel(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["UserId"]), Convert.ToString(reader["Message"]), Convert.ToInt32(reader["DreamId"])));
            return dataComments;
        }

        public List<CommentDataModel> GetByUserId(int userId)
        {
            using SqlConnection conn = new SqlConnection(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Comment WHERE UserId = '{userId}'");
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

        public CommentDataModel AddComment(CommentDataModel dataComment)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"INSERT INTO Comment (UserId, Message, DreamId) OUTPUT INSERTED.ID VALUES (@UserId, @Message, @DreamId)", conn);

            query.Parameters.AddWithValue("@UserId", dataComment.UserId);
            query.Parameters.AddWithValue("@Message", dataComment.Message);
            query.Parameters.AddWithValue("@DreamId", dataComment.DreamId);

            int newId;
            try
            {
                conn.Open();
                newId = (int)query.ExecuteScalar();
            }
            catch
            {
                throw new Exception("CommentSqlData AddComment failed.");
            }

            return new(newId, dataComment.UserId, dataComment.Message, dataComment.DreamId);
        }
    }
}
