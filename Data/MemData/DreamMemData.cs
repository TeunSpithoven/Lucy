using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Containers;
using Data.Interfaces;
using Data.Models;

namespace Data.MemData
{
    public class DreamMemData : IDreamData
    {
        public void AddDream(DreamDataModel dataDream)
        {
            DreamDataContainer.Items.Add(dataDream);
        }

        public void RemoveDreamById(int id)
        {
            DreamDataContainer.Items.RemoveAll(x => x.Id == id);
        }

        public List<DreamDataModel> GetDreams()
        {
            return DreamDataContainer.Items;
        }

        public List<DreamDataModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> returnDreams = new();
            
            foreach (var dream in DreamDataContainer.Items)
            {
                if (dream.UserId == userId)
                {
                    returnDreams.Add(dream);
                }
            }

            return returnDreams;
        }

        public DreamDataModel GetDreamById(int id)
        {
            return DreamDataContainer.Items.Find(x => x.Id == id);
        }
    }
}
