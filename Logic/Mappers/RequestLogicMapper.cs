using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.Models;
using Logic.Models;

namespace Logic.Mappers
{
    public static class RequestLogicMapper
    {
        public static RequestLogicModel DataToLogicRequestModel(RequestDataModel d)
        {
            return new RequestLogicModel(d.Id, new UserLogicModel(d.User1), new UserLogicModel(d.User2), d.Confirmed);
        }
    }
}
