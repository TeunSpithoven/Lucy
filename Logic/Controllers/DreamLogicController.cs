using Data.Controllers;
using Data.Factories;
using Data.Interfaces;
using Data.Models;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DreamLogicController : IDreamLogicController
    {
        public void AddDreamToContainer(DreamLogicModel logicDream)
        {
            DreamDataControllerFactory dreamDataControllerFactory = new();
            IDreamDataController dataController = dreamDataControllerFactory.DreamDataController();
            DreamDataModel dataDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
            dataController.AddDream(dataDream);
        }

        public void RemoveDreamFromContainer(DreamLogicModel logicDream)
        {
            DreamDataControllerFactory dreamDataControllerFactory = new();
            IDreamDataController dataController = dreamDataControllerFactory.DreamDataController();
            DreamDataModel dataDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
            dataController.RemoveDream(dataDream);
        }

        public List<DreamLogicModel> GetDreamsFromContainer()
        {
            DreamDataControllerFactory dreamDataControllerFactory = new();
            IDreamDataController dataController = dreamDataControllerFactory.DreamDataController();
            List<DreamDataModel> dataDreams = dataController.GetDreams();
            List<DreamLogicModel> returnList = new();
            foreach(DreamDataModel dataDream in dataDreams)
            {
                DreamLogicModel logicDream = new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story);
                returnList.Add(logicDream);
            }
            return returnList;
        }
    }
}
