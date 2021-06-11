using DataInterface.Interfaces;
using DataInterface.Models;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;

namespace Logic
{
    public class RequestLogic : IRequestLogic
    {
        private readonly IRequestData _requestData;
        public RequestLogic(IRequestData requestData)
        {
            _requestData = requestData;
        }

        public RequestLogicModel Create(int userId1, int userId2)
        {
            RequestDataModel dataRequest = _requestData.Create(userId1, userId2);
            return RequestLogicMapper.DataToLogicRequestModel(dataRequest);
        }

        public int Accept(int requestId)
        {
            return _requestData.Accept(requestId);
        }

        public int Deny(int requestId)
        {
            return _requestData.Deny(requestId);
        }
    }
}
