using DataInterface.Models;

namespace DataInterface.Interfaces
{
    public interface IRequestData
    {
        public RequestDataModel Create(int userId1, int userId2);
        public int Accept(int requestId);
        public int Deny(int requestId);
    }
}
