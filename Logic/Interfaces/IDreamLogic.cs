﻿using System.Collections.Generic;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IDreamLogic
    {
        public DreamLogicModel Create(int userId, string title, string story);
        public int RemoveDream(int id);
        public List<DreamLogicModel> GetDreams();
        public List<DreamLogicModel> GetDreamsByUserId(int userId);
        public DreamLogicModel GetDreamById(int id);
        // public List<DreamLogicModel> GetDreamsFromFriendsByUserId(int userId);
    }
}
