using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class UserLogicMapper
    {
        public static UserDataModel LogicToDataUserModel(UserLogicModel logicUser)
        {
            if (logicUser == null) return null;
            return new(logicUser.Id, logicUser.Username, logicUser.Password, logicUser.LoggedIn, logicUser.CreationDateTime);
        }

        public static UserLogicModel DataToLogicUserModel(UserDataModel dataUser)
        {
            if (dataUser == null) return null;
            return new(dataUser.Id, dataUser.Username, dataUser.Password, dataUser.LoggedIn, dataUser.CreationDateTime);
        }
    }
}
