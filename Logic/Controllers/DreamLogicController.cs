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
        public void AddDream(DreamLogicModel logicDream)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            DreamDataModel dataDream = new(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story, logicDream.CreationDateTime);
            dreamDataController.AddDreamToDB(dataDream);
        }

        public void RemoveDream(int id)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            dreamDataController.RemoveDreamByIdFromDB(id);
        }

        public List<DreamLogicModel> GetDreams()
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            List<DreamDataModel> dataDreams = dreamDataController.GetDreamsFromDB();
            List<DreamLogicModel> logicDreams = new();
            foreach (var dataDream in dataDreams)
            {
                DreamLogicModel newLogicDream = new DreamLogicModel(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public List<DreamLogicModel> GetDreamsByUserId(int userId)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            List<DreamDataModel> dataDreams = dreamDataController.GetDreamsByUserIdFromDB(userId);
            List<DreamLogicModel> logicDreams = new();
            foreach (var dataDream in dataDreams)
            {
                DreamLogicModel newLogicDream = new DreamLogicModel(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime);
                logicDreams.Add(newLogicDream);
            }
            return logicDreams;
        }

        public DreamLogicModel GetDreamById(int id)
        {
            DreamDataControllerFactory dataControllerFactory = new();
            IDreamDataController dreamDataController = dataControllerFactory.DreamDataController();
            DreamDataModel dataDream = dreamDataController.GetDreamById(id);
            DreamLogicModel logicDream = new(dataDream.Id, dataDream.UserId, dataDream.Title, dataDream.Story, dataDream.CreationDateTime);
            return logicDream;
        }
    }
}
