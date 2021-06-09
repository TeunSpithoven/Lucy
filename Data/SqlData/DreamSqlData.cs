using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Data.SqlData
{
    public class DreamSqlData : IDreamData
    {
        // CREATE
        public void AddDream(DreamDataModel dataDream)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Dream (UserId, Title, Story, CreationDateTime) VALUES (@UserId, @Title, @Story, @CreationDateTime)", conn);
            DateTime now = DateTime.Now;

            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@UserId", dataDream.UserId);
            query.Parameters.AddWithValue("@Title", dataDream.Title);
            query.Parameters.AddWithValue("@Story", dataDream.Story);
            query.Parameters.AddWithValue("@CreationDateTime", now);
            query.ExecuteNonQuery();
        }

        // READ
        public List<DreamDataModel> GetDreams()
        {
            List<DreamDataModel> returnList = new();

            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, Title, Story, CreationDateTime from Dream", conn);
            //database connectie openen
            conn.Open();

            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);

                DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);

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
            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@UserId", userId);
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }

            return returnList;
        }

        public DreamDataModel GetDreamById(int id)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, CreationDateTime, Title, Story from Dream WHERE Id = @Id;", conn);
            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@Id", id);
            var reader = query.ExecuteReader();

            reader.Read();
            // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
            int newDreamId = Convert.ToInt32(reader["Id"]);
            int newDreamUserId = Convert.ToInt32(reader["UserId"]);
            DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
            string newDreamTitle = reader["Title"].ToString();
            string newDreamStory = reader["Story"].ToString();

            DreamDataModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);
            return newDream;
        }

        // DELETE
        public void RemoveDreamById(int id)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("DELETE FROM Dream WHERE ID = @id;", conn);
            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@id", id);
            query.ExecuteNonQuery();
        }
    }
}