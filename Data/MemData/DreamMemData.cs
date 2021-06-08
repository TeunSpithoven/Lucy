using System.Collections.Generic;
using Data.Interfaces;
using Data.Models;
using System.Linq;

namespace Model.MemData
{
    public class DreamMemData : IDreamData
    {
        public static List<DreamDataModel> Items = new();

        public void AddDream(DreamDataModel dataDream)
        {
            Items.Add(dataDream);
        }

        public void RemoveDreamById(int id)
        {
            if (Items.Exists(x => x.Id == id))
            {
                Items.RemoveAll(x => x.Id == id);
            }
        }

        public List<DreamDataModel> GetDreams()
        {
            return Items;
        }

        public List<DreamDataModel> GetDreamsByUserId(int userId)
        {
            List<DreamDataModel> returnDreams = new();
            foreach (var dream in Items)
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
            return Items.Find(x => x.Id == id);
        }
    }
}
