using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IRequestLogic
    {
        public RequestLogicModel Create(int userId1, int userId2);
        public int Accept(int requestId);
        public int Deny(int requestId);
    }
}
