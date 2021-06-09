using System.Collections.Generic;
using DataInterface.Interfaces;
using DataInterface.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserData _userData;
        public UserLogic(IUserData userData)
        {
            _userData = userData;
        }

        public void Create(UserLogicModel logicUser)
        {
            UserDataModel dataUser = UserLogicMapper.LogicToDataUserModel(logicUser); 
            _userData.Create(dataUser);
        }

        public void Login(UserLogicModel logicUser)
        {
            UserDataModel dataUser = UserLogicMapper.LogicToDataUserModel(logicUser);
            _userData.Login(dataUser);
        }

        public void Logout(UserLogicModel logicUser)
        {
            UserDataModel dataUser = UserLogicMapper.LogicToDataUserModel(logicUser);
            _userData.Logout(dataUser);
        }

        public bool UserNameCheck(UserLogicModel logicUser)
        {
            UserDataModel dataUser = UserLogicMapper.LogicToDataUserModel(logicUser);
            return _userData.UserNameCheck(dataUser);
        }

        public List<UserLogicModel> GetFriendList(List<int> friendIdList)
        {
            List<UserDataModel> dataUsers = _userData.GetFriendList(friendIdList);
            List<UserLogicModel> logicUsers = new();
            foreach (UserDataModel dataUser in dataUsers)
            {
                logicUsers.Add(UserLogicMapper.DataToLogicUserModel(dataUser));
            }

            return logicUsers;
        }
    }
}
