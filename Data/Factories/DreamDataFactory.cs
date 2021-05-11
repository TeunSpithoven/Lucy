using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.MemData;
using Data.SqlData;

namespace Data.Factories
{
    public class DreamDataFactory
    {
        public IDreamData DreamSqlData()
        {
           return new DreamSqlData();
        }

        public IDreamData DreamMemData()
        {
            return new DreamMemData();
        }
    }
}
