using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDreamLogicController
    {
        public void AddDreamToContainer(DreamLogicModel logicDream);
        public void RemoveDreamFromContainer(DreamLogicModel logicDream);
        public List<DreamLogicModel> GetDreamsFromContainer();

    }
}
