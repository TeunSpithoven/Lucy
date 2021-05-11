using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDreamData
    {
        public void AddDream(DreamDataModel dataDream);
        public void RemoveDreamById(int id);
        public List<DreamDataModel> GetDreams();
        public List<DreamDataModel> GetDreamsByUserId(int userId);
        public DreamDataModel GetDreamById(int id);
    }
}
