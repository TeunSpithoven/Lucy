using DataInterface.Interfaces;
using DataInterface.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.MemData
{
    public class DreamMemData : IDreamData
    {
        public static List<DreamDataModel> Items = new();
        private static int _id;

        public DreamDataModel AddDream(DreamDataModel dataDream)
        {
            dataDream.Id = _id;
            Items.Add(dataDream);
            _id++;
            return dataDream;
        }

        public int RemoveDreamById(int id)
        {
            List<DreamDataModel> dreams = Items.FindAll(x => x.Id == id);
            if (dreams.Count > 0)
            {
                Items.RemoveAll(x => x.Id == id);
                return id;
            }

            if (dreams.Count >= 2) throw new DuplicateNameException("multiple dreams found with the same id");
            return -1;
        }

        public List<DreamDataModel> GetDreams()
        {
            return Items;
        }

        public List<DreamDataModel> GetDreamsByUserId(int userId)
        {
            return Items.Where(dream => dream.UserId == userId).ToList();
        }

        public DreamDataModel GetDreamById(int id)
        {
            return Items.Find(x => x.Id == id);
        }
    }
}