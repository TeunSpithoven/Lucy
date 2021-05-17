using System.Collections.Generic;
using Data.Containers;
using Data.Mappers;
using Data.Models;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;

namespace Data.MemData
{
    public class DreamMemData : IDreamConnector
    {
        public void AddDream(DreamConnectorModel conDream)
        {
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);
        }

        public void RemoveDreamById(int id)
        {
            DreamDataContainer.Items.RemoveAll(x => x.Id == id);
        }

        public List<DreamConnectorModel> GetDreams()
        {
            List<DreamDataModel> dataDreams = DreamDataContainer.Items;
            List<DreamConnectorModel> conDreams = new();
            foreach (var dream in dataDreams)
            {
                conDreams.Add(DreamDataMapper.DreamDataToConnectorModel(dream));
            }

            return conDreams;
        }

        public List<DreamConnectorModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> dataDreams = new();
            List<DreamConnectorModel> conDreams = new();
            foreach (var dream in dataDreams)
            {
                conDreams.Add(DreamDataMapper.DreamDataToConnectorModel(dream));
            }

            List<DreamConnectorModel> returnDreams = new();
            foreach (var dream in conDreams)
            {
                if (dream.UserId == userId)
                {
                    returnDreams.Add(dream);
                }
            }

            return returnDreams;
        }

        public DreamConnectorModel GetDreamById(int id)
        {
            return DreamDataMapper.DreamDataToConnectorModel(DreamDataContainer.Items.Find(x => x.Id == id));
        }
    }
}
