namespace LogicDataConnector.Models
{
    public class UserDataModel
    {
        public bool IsLoggedIn { get; set; }

        public UserDataModel(bool isLoggedIn)
        {
            isLoggedIn = IsLoggedIn;
        }
    }
}
