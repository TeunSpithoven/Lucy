using System.Collections.Generic;
using System.Data;
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

        public List<RequestLogicModel> GetAll()
        {
            List<RequestDataModel> dataRequests = _requestData.GetAll();
            List<RequestLogicModel> logicRequests = new();
            foreach (RequestDataModel dataRequest in dataRequests)
                logicRequests.Add(RequestLogicMapper.DataToLogicRequestModel(dataRequest));
            return logicRequests;
        }

        public RequestLogicModel Create(int userId1, int userId2)
        {
            if (userId1 == userId2) throw new DuplicateNameException("Both userId's are the same");
            RequestLogicModel logicRequest = new(userId1, userId2, false);
            RequestDataModel dataRequest = RequestLogicMapper.LogicToDataRequestModel(logicRequest);
            RequestDataModel returnRequest = _requestData.Create(dataRequest);
            return RequestLogicMapper.DataToLogicRequestModel(returnRequest);
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
