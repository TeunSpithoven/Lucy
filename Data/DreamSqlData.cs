using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Data
{
    public class DreamSqlData : IDreamData
    {
        // CREATE
        public DreamDataModel AddDream(DreamDataModel dataDream)
        {
            // SET
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Dream (UserId, Title, Story, CreationDateTime)" +
                                            " output INSERTED.ID" +
                                            " VALUES (@UserId, @Title, @Story, @CreationDateTime)", conn);
            query.Parameters.AddWithValue("@UserId", dataDream.UserId);
            query.Parameters.AddWithValue("@Title", dataDream.Title);
            query.Parameters.AddWithValue("@Story", dataDream.Story);
            DateTime now = DateTime.Now;
            query.Parameters.AddWithValue("@CreationDateTime", now);

            int newId;
            try
            {
                conn.Open();
                newId = (int)query.ExecuteScalar();
            }
            catch
            {
                throw new Exception("DreamSqlData GetAll failed.");
            }

            return new DreamDataModel(newId, dataDream.UserId, dataDream.Title, dataDream.Story, now, new List<CommentDataModel>());
        }

        // READ
        public List<DreamDataModel> GetDreams()
        {
            List<DreamDataModel> returnList = new();

            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, Title, Story, CreationDateTime from Dream ORDER BY CreationDateTime DESC", conn);
            //database connectie openen
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("DreamSqlData GetDreams failed.");
            }

            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);

                DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime, new List<CommentDataModel>());

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }
            return returnList;
        }

        public List<DreamDataModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, Title, Story, CreationDateTime from Dream WHERE UserId = @UserId;", conn);
            query.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("DreamSqlData GetDreamsByUserId failed.");
            }

            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime, new List<CommentDataModel>());

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }

            return returnList;
        }

        public DreamDataModel GetDreamById(int id)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, CreationDateTime, Title, Story from Dream WHERE Id = @Id;", conn);
            query.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("DreamSqlData GetDreamById failed.");
            }

            reader.Read();
            // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
            int newDreamId = Convert.ToInt32(reader["Id"]);
            int newDreamUserId = Convert.ToInt32(reader["UserId"]);
            DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
            string newDreamTitle = reader["Title"].ToString();
            string newDreamStory = reader["Story"].ToString();

            DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime, new List<CommentDataModel>());
            return newDream;
        }

        // DELETE
        public int RemoveDreamById(int id)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("DELETE FROM Dream WHERE ID = @id;", conn);
            query.Parameters.AddWithValue("@id", id);
            
            try
            {
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("DreamSqlData RemoveDreamById failed.");
            }

            return id;
        }
    }
}