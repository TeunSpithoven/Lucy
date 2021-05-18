using Data.MemData;
using Data.SqlData;
using LogicDataConnector.Interfaces;

namespace LogicDataConnector.Factories
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
