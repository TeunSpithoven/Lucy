using System.Collections.Generic;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IRequestLogic
    {
        public List<RequestLogicModel> GetAll();
        public RequestLogicModel Create(int userId1, int userId2);
        public int Accept(int requestId);
        public int Deny(int requestId);
    }
}
