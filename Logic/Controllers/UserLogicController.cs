using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Controllers;
using Data.Models;
using Logic.Models;

namespace Logic.Controllers
{
    public class UserLogicController
    {
        public bool IsLoggedIn(UserLogicModel logicUser)
        {
            UserDataModel dataUser = new(logicUser.Id, logicUser.Username, logicUser.Password, logicUser.LoggedIn);
            UserDataController d = new();
            bool isLoggedIn = d.IsLoggedIn(dataUser);
            return isLoggedIn;
        }
    }
}
