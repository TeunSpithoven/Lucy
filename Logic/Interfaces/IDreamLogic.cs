using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IDreamLogic
    {
        public void AddDream(DreamLogicModel logicDream);
        public void RemoveDream(int id);
        public List<DreamLogicModel> GetDreams();
        public List<DreamLogicModel> GetDreamsByUserId(int userId);
        public DreamLogicModel GetDreamById(int id);
    }
}
