using Logic.Models;
using View.Models;

namespace View.Mappers
{
    public static class RequestViewMapper
    {
        public static RequestViewModel LogicToViewRequestModel(RequestLogicModel l)
        {
            return new(l.Id, l.User1, l.User2, l.Confirmed);
        }
    }
}
