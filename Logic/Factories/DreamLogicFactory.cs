using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Logic.Interfaces;

namespace Logic.Factories
{
    public class DreamLogicFactory
    {
        public IDreamLogic DreamLogic(IDreamData dreamData)
        {
            return new DreamLogic(dreamData);
        }
    }
}
