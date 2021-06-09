using System.Collections.Generic;
using DataInterface.Models;

namespace DataInterface.Interfaces
{
    public interface IUserData
    {
        public void Create(UserDataModel dataUser);
        public void Login(UserDataModel dataUser);
        public void Logout(UserDataModel dataUser);
        public bool UserNameCheck(UserDataModel dataUser);
        public List<UserDataModel> GetFriendList(List<int> friendIdList);
    }
}
