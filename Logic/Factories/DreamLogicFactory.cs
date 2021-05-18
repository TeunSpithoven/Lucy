using Logic.Interfaces;
using LogicDataConnector.Interfaces;

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
