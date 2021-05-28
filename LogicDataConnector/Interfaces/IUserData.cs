using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicDataConnector.Models;

namespace LogicDataConnector.Interfaces
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
