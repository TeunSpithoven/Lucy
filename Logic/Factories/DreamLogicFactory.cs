using Logic.Interfaces;
using LogicDataConnector.Interfaces;

namespace Logic.Factories
{
    public class DreamLogicFactory
    {
        public IDreamLogic DreamLogic(IDreamConnector dreamData)
        {
            return new DreamLogic(dreamData);
        }
    }
}
