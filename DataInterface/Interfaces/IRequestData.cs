using System.Collections.Generic;
using DataInterface.Models;

namespace DataInterface.Interfaces
{
    public interface IRequestData
    {
        public List<RequestDataModel> GetAll();
        public RequestDataModel GetById(int id);
        public List<RequestDataModel> GetReceivedByUserId(int userId);
        public List<RequestDataModel> GetSentByUserId(int userId);
        public RequestDataModel Create(RequestDataModel dataRequest);
        public int Accept(int requestId);
        public int Deny(int requestId);
    }
}
