using Data.Models;

namespace Data.SqlData
{
    public class UserSqlData
    {
        public bool IsLoggedIn(UserDataModel dataUser)
        {
            if (dataUser.LoggedIn)
                return true;

            return false;
        }
    }
}
