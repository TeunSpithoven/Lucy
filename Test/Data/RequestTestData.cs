﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataInterface.Interfaces;
using DataInterface.Models;

namespace Test.Data
{
    public class RequestTestData : IRequestData
    {
        public static List<RequestDataModel> Items = new();
        private static int _id;
        public List<RequestDataModel> GetAll()
        {
            return Items;
        }

        public RequestDataModel GetById(int id)
        {
            List<RequestDataModel> foundRequests = Items.FindAll(request => request.Id == id);
            return foundRequests.Count <= 0 ? foundRequests[0] : null;
        }

        public List<RequestDataModel> GetReceivedByUserId(int userId)
        {
            return Items.Where(x => x.User2 == userId).ToList();
        }

        public List<RequestDataModel> GetSentByUserId(int userId)
        {
            return Items.Where(x => x.User1 == userId).ToList();
        }

        public RequestDataModel AddRequest(RequestDataModel dataRequest)
        {
            RequestDataModel newRequest = new(_id, dataRequest.User1, dataRequest.User2, dataRequest.Confirmed);
            _id++;
            Items.Add(newRequest);
            return newRequest;
        }

        public int Accept(int requestId)
        {
            int index = Items.FindIndex(x => x.Id == requestId);
            Items[index].Confirmed = true;
            return requestId;
        }

        public int Deny(int requestId)
        {
            RequestDataModel request = Items.Find(x => x.Id == requestId);
            Items.RemoveAll(x => x.Id == requestId);
            return requestId;
        }
    }
}
