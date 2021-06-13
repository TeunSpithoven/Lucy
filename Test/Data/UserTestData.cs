using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Data.MemData
{
    public class UserTestData : IUserData
    {
        public static List<UserDataModel> Items = new();

        public void Create(UserDataModel dataUser)
        {
            Items.Add(dataUser);
        }

        public void Login(UserDataModel dataUser)
        {
            var user = Items.Find(x => x.Id == dataUser.Id);
            if (user == null) return;
            user.LoggedIn = true;
        }

        public void Logout(UserDataModel dataUser)
        {
            var user = Items.Find(x => x.Id == dataUser.Id);
            if (user == null) return;
            user.LoggedIn = false;
        }

        public bool UserNameCheck(UserDataModel dataUser)
        {
            var users = Items.FindAll(x => x.Username == dataUser.Username);
            return users.Count == 0;
        }

        public List<UserDataModel> GetFriendList(List<int> friendIdList)
        {
            List<UserDataModel> friends = new();
            foreach (int Id in friendIdList)
            {
                UserDataModel friend = Items.Find(x => x.Id == Id);
                if (friend != null)
                    friends.Add(friend);
            }

            return friends;
        }
    }
}
