using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDreamDataController
    {
        public void AddDream(DreamDataModel logicDream);
        public void RemoveDream(DreamDataModel logicDream);
        public List<DreamDataModel> GetDreams();
    }
}
