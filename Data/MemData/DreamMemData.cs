﻿using System.Collections.Generic;
using Data.Interfaces;
using Data.Models;
using System.Linq;

namespace Data.MemData
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
                Items.RemoveAll(x => x.Id == id);
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
