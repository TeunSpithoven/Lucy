using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.SqlData;
using DataInterface.Models;
using Logic;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Data;

namespace Test.Logic
{
    [TestClass]
    public class RequestLogicTest
    {
        [TestMethod]
        public void GetAll_ThreeRequestsSaved_ReturnsThreeRequests()
        {
            RequestDataModel request1 = new(0, 2, 55, false);
            RequestDataModel request2 = new(1, 6, 674, false);
            RequestDataModel request3 = new(2, 3, 654645, false);
            RequestTestData.Items.Clear();
            RequestTestData.Items.Add(request1);
            RequestTestData.Items.Add(request2);
            RequestTestData.Items.Add(request3);
            RequestLogic requestLogic = new(new RequestTestData());

            List<RequestLogicModel> requests = requestLogic.GetAll();

            Assert.AreEqual(3, requests.Count);
            Assert.AreEqual(0, requests[0].Id);
            Assert.AreEqual(1, requests[1].Id);
            Assert.AreEqual(2, requests[2].Id);
        }

        [TestMethod]
        public void GetAll_NoRequestsSaved_ReturnsEmptyList()
        {
            RequestLogic requestLogic = new(new RequestTestData());
            RequestTestData.Items.Clear();

            List<RequestLogicModel> requests = requestLogic.GetAll();

            Assert.AreEqual(0, requests.Count);
        }

        [TestMethod]
        public void Create_IdOneIsSevenIdTwoIsTwenty_ReturnsAddedRequest()
        {
            RequestLogic requestLogic = new(new RequestTestData());

            RequestLogicModel returnRequest = requestLogic.Create(7, 20);

            Assert.AreEqual(7, returnRequest.User1);
            Assert.AreEqual(20, returnRequest.User2);
        }
    }
}
