using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IDreamLogicController
    {
        public void AddDream(DreamLogicModel viewDream);
        public void RemoveDream(int id);
        public List<DreamLogicModel> GetDreams();
    }
}
