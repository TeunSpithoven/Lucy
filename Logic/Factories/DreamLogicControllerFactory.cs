using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Controllers;
using Logic.Interfaces;

namespace Logic.Factories
{
    public class DreamLogicControllerFactory
    {
        public IDreamLogicController DreamLogicController()
        {
            return new DreamLogicController();
        }
    }
}
