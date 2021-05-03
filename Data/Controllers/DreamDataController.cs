using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data.Controllers
{
    public class DreamDataController : IDreamDataController
    {
        // CREATE
        public void AddDreamToDB(DreamDataModel dataDream)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Dream (UserId, CreationDate, Title, Story) VALUES (@UserId, @CreationDate, @Title, @Story)", conn);
            DateTime now = DateTime.Now;

            //database connectie openen
            conn.Open();
            // query.Parameters.AddWithValue("@Id", dataDream.Id);
            query.Parameters.AddWithValue("@UserId", dataDream.UserId);
            query.Parameters.AddWithValue("@CreationDate", now);
            query.Parameters.AddWithValue("@Title", dataDream.Title);
            query.Parameters.AddWithValue("@Story", dataDream.Story);
            query.ExecuteNonQuery();
        }

        // READ
        public List<DreamDataModel> GetDreamsFromDB()
        {
            List<DreamDataModel> returnList = new();

            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, CreationDate, Title, Story from Dream", conn);
            //database connectie openen
            conn.Open();

            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                // DateTime newDreamUserDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamDataModel newDream = new DreamDataModel(newDreamId, newDreamUserId, newDreamTitle, newDreamStory);

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }
            return returnList;
        }

        public List<DreamDataModel> GetDreamsByUserIdFromDB(int userId)
        {
            List<DreamDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, CreationDate, Title, Story from Dream WHERE UserId = @UserId;", conn);
            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@UserId", userId);
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                int newDreamId = Convert.ToInt32(reader["Id"]);
                int newDreamUserId = Convert.ToInt32(reader["UserId"]);
                // DateTime newDreamUserDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamDataModel newDream = new DreamDataModel(newDreamId, newDreamUserId, newDreamTitle, newDreamStory);

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }

            return returnList;
        }

        public DreamDataModel GetDreamById(int id)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("select Id, UserId, CreationDate, Title, Story from Dream WHERE Id = @Id;", conn);
            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@Id", id);
            var reader = query.ExecuteReader();

            reader.Read();
            // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
            int newDreamId = Convert.ToInt32(reader["Id"]);
            int newDreamUserId = Convert.ToInt32(reader["UserId"]);
            // DateTime newDreamUserDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
            string newDreamTitle = reader["Title"].ToString();
            string newDreamStory = reader["Story"].ToString();

            DreamDataModel newDream = new DreamDataModel(newDreamId, newDreamUserId, newDreamTitle, newDreamStory);
            return newDream;
        }

        // DELETE
        public void RemoveDreamByIdFromDB(int id)
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