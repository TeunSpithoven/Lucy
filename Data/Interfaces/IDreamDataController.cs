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
        public void RemoveDream(int id);
        public List<DreamDataModel> GetDreams();
    }
}
