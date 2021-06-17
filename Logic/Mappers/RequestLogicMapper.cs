using DataInterface.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class RequestLogicMapper
    {
        public static RequestLogicModel DataToLogicRequestModel(RequestDataModel d)
        {
            return new (d.Id, d.User1, d.User2, d.Confirmed);
        }

        public static RequestDataModel LogicToDataRequestModel(RequestLogicModel l)
        {
            return new (l.User1, l.User2, l.Confirmed);
        }
    }
}
