using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
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
            ValidationContext context = new ValidationContext(new RequestLogicModel()) { MemberName = "User1" };
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(userId1, context, errors))
            {
                throw new ValidationException("RequestLogic Create validation failed");
            }
            if (userId1 == userId2) throw new DuplicateNameException("Both userId's are the same");
            RequestLogicModel logicRequest = new(userId1, userId2, false);
            RequestDataModel dataRequest = RequestLogicMapper.LogicToDataRequestModel(logicRequest);
            RequestDataModel returnRequest = _requestData.AddRequest(dataRequest);
            return RequestLogicMapper.DataToLogicRequestModel(returnRequest);
        }

        // TODO: return RequestLogicModel instead of int for testability
        public int Accept(int requestId)
        {
            ValidationContext context = new(new RequestLogicModel()) { MemberName = "Id" };
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(requestId, context, errors))
            {
                throw new ValidationException("RequestLogic Accept validation failed");
            }
            return _requestData.Accept(requestId);
        }

        // TODO: return RequestLogicModel instead of int for testabiity
        public int Deny(int requestId)
        {
            ValidationContext context = new(new RequestLogicModel()) { MemberName = "Id" };
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(requestId, context, errors))
            {
                throw new ValidationException("RequestLogic Deny validation failed");
            }
            return _requestData.Deny(requestId);
        }
    }
}
