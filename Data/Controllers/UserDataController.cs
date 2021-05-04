using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Controllers
{
    public class UserDataController
    {
        public bool IsLoggedIn(UserDataModel dataUser)
        {
            if (dataUser.LoggedIn)
                return true;

            return false;
        }
    }
}
