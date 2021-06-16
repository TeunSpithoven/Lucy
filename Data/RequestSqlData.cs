using DataInterface.Interfaces;
using DataInterface.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Data.SqlData
{
    public class RequestSqlData : IRequestData
    {
        public List<RequestDataModel> GetAll()
        {
            List<RequestDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("SELECT * FROM Request", conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("RequestSql GetAll failed.");
            }

            if (!reader.HasRows) return returnList;
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int userId1 = Convert.ToInt32(reader["User1"]);
                int userId2 = Convert.ToInt32(reader["User2"]);
                bool confirmed = Convert.ToBoolean(reader["Confirmed"]);

                RequestDataModel request = new(id, userId1, userId2, confirmed);

                returnList.Add(request);
            }
            return returnList;
        }

        public RequestDataModel GetById(int id)
        {
            List<RequestDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Request WHERE Id = '{id}'", conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("RequestSql GetById failed.");
            }
            int userId1 = Convert.ToInt32(reader["User1"]);
            int userId2 = Convert.ToInt32(reader["User2"]);
            bool confirmed = Convert.ToBoolean(reader["Confirmed"]);

            return new RequestDataModel(id, userId1, userId2, confirmed);
        }

        public List<RequestDataModel> GetReceivedByUserId(int userId)
        {
            List<RequestDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Request WHERE User2 = {userId}", conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("RequestSql GetReceivedByUserId failed.");
            }
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int userId1 = Convert.ToInt32(reader["User1"]);
                int userId2 = userId;
                bool confirmed = Convert.ToBoolean(reader["Confirmed"]);

                RequestDataModel request = new(id, userId1, userId2, confirmed);

                returnList.Add(request);
            }
            return returnList;
        }

        public List<RequestDataModel> GetSentByUserId(int userId)
        {
            List<RequestDataModel> returnList = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Request WHERE User1 = {userId}", conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("RequestSql GetSentByUserId failed.");
            }
            
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                int userId1 = userId;
                int userId2 = Convert.ToInt32(reader["User2"]);
                bool confirmed = Convert.ToBoolean(reader["Confirmed"]);

                RequestDataModel request = new(id, userId1, userId2, confirmed);

                returnList.Add(request);
            }
            return returnList;
        }

        public RequestDataModel Create(RequestDataModel dataRequest)
        {
            int newId;
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Request (User1, User2, Confirmed) " +
                                         "OUTPUT INSERTED.ID VALUES (@User1, @User2, @Confirmed)", conn);
            query.Parameters.AddWithValue("@User1", dataRequest.User1);
            query.Parameters.AddWithValue("@User2", dataRequest.User2);
            query.Parameters.AddWithValue("@Confirmed", false);

            try
            {
                conn.Open();
                newId = (int)query.ExecuteScalar();
            }
            catch
            {
                throw new Exception("Sql Create Request failed.");
            }

            return new RequestDataModel(newId, dataRequest.User1, dataRequest.User2, false);
        }

        public int Accept(int requestId)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("UPDATE Request SET Confirmed = 'true' WHERE Id = @Id", conn);
            query.Parameters.AddWithValue("@Id", requestId);

            conn.Open();
            try
            {
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new KeyNotFoundException($"Accept request with id:{requestId} failed.");
            }

            return requestId;
        }

        public int Deny(int requestId)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("DELETE FROM Request WHERE Id = @Id", conn);
            query.Parameters.AddWithValue("@Id", requestId);

            conn.Open();
            try
            {
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new KeyNotFoundException($"Deny request with id:{requestId} failed.");
            }
            return requestId;
        }
    }
}