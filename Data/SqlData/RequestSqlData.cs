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
    public class RequestSqlData : IRequestData
    {
        public RequestDataModel Create(int userId1, int userId2)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("INSERT INTO Request (User1, User2, Confirmed) " +
                                         "VALUES (@User1, @User2, @Confirmed)", conn);
            query.Parameters.AddWithValue("@User1", userId1);
            query.Parameters.AddWithValue("@User2", userId2);
            query.Parameters.AddWithValue("@Confirmed", false);

            conn.Open();
            query.ExecuteNonQuery();

            return new RequestDataModel(userId1, userId2, false);
        }

        public int Accept(int requestId)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("UPDATE Request SET Confirmed = true WHERE Id = @Id", conn);
            query.Parameters.AddWithValue("@Id", requestId);

            conn.Open();
            query.ExecuteNonQuery();

            return requestId;
        }

        public int Deny(int requestId)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new("DELETE FROM Request WHERE Id = @Id", conn);
            query.Parameters.AddWithValue("@Id", requestId);

            conn.Open();
            query.ExecuteNonQuery();
            return requestId;
        }
    }
}
