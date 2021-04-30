using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Factories;
using Data.Interfaces;
using Data.Models;
using Logic.Interfaces;
using Logic.Models;


namespace Logic.Controllers
{
    public class DreamLogicController : IDreamLogicController
    {
        public void AddDream(DreamLogicModel viewDream)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            DreamDataModel dataDream = new(viewDream.Id, viewDream.UserId, viewDream.Title, viewDream.Story);
            dreamDataController.AddDream(dataDream);
        }

        public void RemoveDream(int id)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            dreamDataController.RemoveDream(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            List<DreamDataModel> dataDreams = dreamDataController.GetDreams();
            List<DreamLogicModel> logicDreams = new();
            foreach (var dataDream in dataDreams)
            {
                DreamLogicModel newLogicDream = new DreamLogicModel(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }
    }
}
