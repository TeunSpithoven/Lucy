using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Data
{
    public class UserSqlData : IUserData
    {
        public void AddUser(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            // declaring command
            using SqlCommand query = new("INSERT INTO Users (Username, Password, LoggedIn, CreationDateTime) VALUES (@_Username, @_Password, @_LoggedIn, @_CreationDateTime)", conn);
            DateTime now = DateTime.Now;
            // add parameters
            query.Parameters.AddWithValue("@_Username", dataUser.Username);
            query.Parameters.AddWithValue("@_Password", dataUser.Password);
            query.Parameters.AddWithValue("@_LoggedIn", dataUser.LoggedIn);
            query.Parameters.AddWithValue("@_CreationDateTime", now);
            try
            {
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("UserSqlData Create failed.");
            }
        }

        public void Login(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"UPDATE Users SET LoggedIn = _LoggedIn WHERE Id = @_Id");
            query.Parameters.AddWithValue("@_LoggedIn", true);
            query.Parameters.AddWithValue("@_Id", dataUser.Id);
            
            try
            {
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("UserSqlData Login failed.");
            }
        }

        public void Logout(UserDataModel dataUser)
        {
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"UPDATE Users SET LoggedIn = _LoggedIn WHERE Id = @_Id");
            query.Parameters.AddWithValue("@_LoggedIn", false);
            query.Parameters.AddWithValue("@_Id", dataUser.Id);
            try
            {
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("UserSqlData Logout failed.");
            }
        }

        public bool UserNameCheck(UserDataModel dataUser)
        {
            List<string> foundUsernames = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT Username FROM Users WHERE Username = @_Username");
            query.Parameters.AddWithValue("@_Username", dataUser.Username);

            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
            }
            catch
            {
                throw new Exception("UserSqlData UsernameCheck failed.");
            }
            while (reader.Read())
                foundUsernames.Add(reader["Username"].ToString());
            return foundUsernames.Count < 1;
        }

        public List<UserDataModel> GetFriendList(List<int> friendIdList)
        {
            List<UserDataModel> friends = new();
            using SqlConnection conn = new(DataBaseConnection.String);
            using SqlCommand query = new($"SELECT * FROM Users WHERE Id = @_Id");
            
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("UserSqlData GetFriendList Connection failed.");
            }

            foreach (int id in friendIdList)
            {
                query.Parameters.AddWithValue("@_Username", id);
                SqlDataReader reader;
                try
                {
                    conn.Open();
                    reader = query.ExecuteReader();
                }
                catch
                {
                    throw new Exception("UserSqlData GetFriendList Reader failed.");
                }
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
