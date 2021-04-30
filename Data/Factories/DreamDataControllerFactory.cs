using Data.Controllers;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories
{
    public class DreamDataControllerFactory
    {
        public IDreamDataController DreamDataController()
        {
           return new DreamDataController();
        }
    }
}
