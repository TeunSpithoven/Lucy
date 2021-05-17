using Data.Models;
using LogicDataConnector.Models;

namespace Data.Mappers
{
    public static class DreamDataMapper
    {
        public static DreamDataModel DreamConnectorToDataModel(DreamConnectorModel conModel)
        {
            return new DreamDataModel(conModel.Id, conModel.UserId, conModel.Title, conModel.Story, conModel.CreationDateTime);
        }

        public static DreamConnectorModel DreamDataToConnectorModel(DreamDataModel dataModel)
        {
            return new DreamConnectorModel(dataModel.Id, dataModel.UserId, dataModel.Title, dataModel.Story, dataModel.CreationDateTime);
        }
    }
}
