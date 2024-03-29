﻿using System.Collections.Generic;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        public void Create(int id, string username, string password);
        public void Login(UserLogicModel logicUser);
        public void Logout(UserLogicModel logicUser);
        public bool UserNameCheck(UserLogicModel logicUser);
        public List<UserLogicModel> GetFriendList(List<int> friendIdList);
    }
}
