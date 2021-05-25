using LogicDataConnector.Models;

namespace Data.SqlData
{
    public class UserSqlData
    {
        public bool IsLoggedIn(UserDataModel dataUser)
        {
            if (dataUser.IsLoggedIn)
                return true;

            return false;
        }
    }
}
