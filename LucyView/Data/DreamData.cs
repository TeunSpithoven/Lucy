using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucy5.Models;
using Microsoft.Data.SqlClient;

namespace Lucy5.Data
{
    public class DreamData
    {
        private string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Lucy; Integrated Security = True; Connect Timeout = 30; " +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<Dream> GetDreamsFromDatabase()
        {
            List<Dream> returnList = new List<Dream>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select Id, UserId, CreationDate, Title, Story from Dream", conn))
                {
                    //database connectie openen
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        // pakt voor alle dromen in de database uit de kolommen de data en zet die om naar een object.
                        Dream newDream = new Dream();
                        newDream.Id = Convert.ToInt32(reader["Id"]);
                        // newDream.UserId = Convert.ToInt32(reader["UserId"]);
                        newDream.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                        newDream.Title = reader["Title"].ToString();
                        newDream.Story = reader["Story"].ToString();
                        
                        // voegd die droom toe aan de lijst
                        returnList.Add(newDream);
                    }
                }
            }
            
            return returnList;
        }

        public void RemoveDreamFromDatabase(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("DELETE FROM Dream WHERE ID = @id;", conn))
                {
                    //database connectie openen
                    conn.Open();
                    query.Parameters.AddWithValue("@id", id);
                    query.ExecuteNonQuery();
                }
            }
        }

        public void AddDreamToDatabase(Dream dream)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("INSERT INTO Dream (CreationDate, Title, Story) VALUES (@CreationDate, @Title, @Story)", conn))
                {
                    DateTime now = DateTime.Now;
                    
                    //database connectie openen
                    conn.Open();
                    // query.Parameters.AddWithValue("@Id", id);
                    // query.Parameters.AddWithValue("@UserId", id);
                    query.Parameters.AddWithValue("@CreationDate", now);
                    query.Parameters.AddWithValue("@Title", dream.Title);
                    query.Parameters.AddWithValue("@Story", dream.Story);
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
