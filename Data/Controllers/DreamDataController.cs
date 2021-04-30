using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    public class DreamDataController : IDreamDataController
    {
        public void AddDream(DreamDataModel logicDream)
        {
            DreamDataModel dataDream = new DreamDataModel(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
            DreamDataContainer.Items.Add(dataDream);
        }

        public void RemoveDream(DreamDataModel logicDream)
        {
            DreamDataModel dataDream = new DreamDataModel(logicDream.Id, logicDream.UserId, logicDream.Title, logicDream.Story);
            DreamDataContainer.Items.Remove(dataDream);
        }

        public List<DreamDataModel> GetDreams()
        {
            List<DreamDataModel> dataDreams = DreamDataContainer.Items;
            return dataDreams;
        }
    }
}
