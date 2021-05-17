using Data.MemData;
using Data.SqlData;
using LogicDataConnector.Interfaces;

namespace LogicDataConnector.Factories
{
    public class DreamDataFactory
    {
        public IDreamConnector DreamSqlData()
        {
            return new DreamSqlData();
        }

        public IDreamConnector DreamMemData()
        {
            return new DreamMemData();
        }
    }
}
