using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data.Models;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;

namespace Data.SqlData
{
    public class DreamSqlData : IDreamConnector
    {
        // CREATE
        public void AddDream(DreamConnectorModel dataDream)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Dream (UserId, CreationDate, Title, Story) VALUES (@UserId, @CreationDate, @Title, @Story)", conn);
            DateTime now = DateTime.Now;

            //database connectie openen
            conn.Open();
            query.Parameters.AddWithValue("@UserId", dataDream.UserId);
            query.Parameters.AddWithValue("@CreationDate", now);
            query.Parameters.AddWithValue("@Title", dataDream.Title);
            query.Parameters.AddWithValue("@Story", dataDream.Story);
            query.ExecuteNonQuery();
        }

        // READ
        public List<DreamConnectorModel> GetDreams()
        {
            List<DreamConnectorModel> returnList = new();

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
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDate"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamConnectorModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }
            return returnList;
        }

        public List<DreamConnectorModel> GetDreamsByUserId(int userId)
        {
            List<DreamConnectorModel> returnList = new();
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
                DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDate"]);
                string newDreamTitle = reader["Title"].ToString();
                string newDreamStory = reader["Story"].ToString();

                DreamConnectorModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);

                // voegd die droom toe aan de lijst
                returnList.Add(newDream);
            }

            return returnList;
        }

        public DreamConnectorModel GetDreamById(int id)
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
            DateTime newDreamDateTime = Convert.ToDateTime(reader["CreationDate"]);
            string newDreamTitle = reader["Title"].ToString();
            string newDreamStory = reader["Story"].ToString();

            DreamConnectorModel newDream = new(newDreamId, newDreamUserId, newDreamTitle, newDreamStory, newDreamDateTime);
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