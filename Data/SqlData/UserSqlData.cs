using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;

namespace Data.SqlData
{
    public class UserSqlData : IUserData
    {
        public void Create(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            // declaring command
            using SqlCommand query = new("INSERT INTO Users (Username, Password, LoggedIn, CreationDateTime) VALUES (@_Username, @_Password, @_LoggedIn, @_CreationDateTime)", conn);
            DateTime now = DateTime.Now;

            //database connectie openen
            conn.Open();
            // add parameters
            query.Parameters.AddWithValue("@_Username", dataUser.Username);
            query.Parameters.AddWithValue("@_Password", dataUser.Password);
            query.Parameters.AddWithValue("@_LoggedIn", dataUser.LoggedIn);
            query.Parameters.AddWithValue("@_CreationDateTime", now);
            // execute command
            query.ExecuteNonQuery();
        }

        public void Login(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"UPDATE Users SET LoggedIn = _LoggedIn WHERE Id = @_Id");
            conn.Open();
            query.Parameters.AddWithValue("@_LoggedIn", true);
            query.Parameters.AddWithValue("@_Id", dataUser.Id);
            query.ExecuteNonQuery();
        }

        public void Logout(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"UPDATE Users SET LoggedIn = _LoggedIn WHERE Id = @_Id");
            conn.Open();
            query.Parameters.AddWithValue("@_LoggedIn", false);
            query.Parameters.AddWithValue("@_Id", dataUser.Id);
            query.ExecuteNonQuery();
        }

        public bool UserNameCheck(UserDataModel dataUser)
        {
            List<string> foundUsernames = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT Username FROM Users WHERE Username = @_Username");
            conn.Open();
            query.Parameters.AddWithValue("@_Username", dataUser.Username);
            var reader = query.ExecuteReader();
            while (reader.Read())
                foundUsernames.Add(reader["Username"].ToString());
            return foundUsernames.Count < 1;
        }

        public List<UserDataModel> GetFriendList(List<int> friendIdList)
        {
            List<UserDataModel> friends = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Users WHERE Id = @_Id");
            conn.Open();
            foreach (int id in friendIdList)
            {
                query.Parameters.AddWithValue("@_Username", id);
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    string username = reader["Username"].ToString();
                    string password = reader["Password"].ToString();
                    bool loggedIn = Convert.ToBoolean(reader["LoggedIn"]);
                    DateTime creationDateTime = Convert.ToDateTime(reader["CreationDateTime"]);
                    friends.Add(new UserDataModel(id, username, password, loggedIn, creationDateTime));
                }
            }
            return friends;
        }
    }
}
