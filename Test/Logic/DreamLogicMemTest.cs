using System.Collections.Generic;
using System.Linq;
using Data.Containers;
using Data.Mappers;
using Data.MemData;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Logic
{
    [TestClass]
    public class DreamLogicMemTest
    {
        [TestMethod]
        public void AddDream()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);

            //act
            iDreamLogic.AddDream(logicDream);

            //assert
            int amountOfDreamsInMemory = DreamDataContainer.Items.Count;
            Assert.AreNotEqual(0, amountOfDreamsInMemory);

            DreamDataModel firstDreamInMemory = DreamDataContainer.Items.First();

            Assert.AreEqual(conDream.Id, firstDreamInMemory.Id);
            Assert.AreEqual(conDream.UserId, firstDreamInMemory.UserId);
            Assert.AreEqual(conDream.Title, firstDreamInMemory.Title);
            Assert.AreEqual(conDream.Story, firstDreamInMemory.Story);
        }

        [TestMethod]
        public void RemoveDream_DreamExists_Success()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            iDreamLogic.RemoveDream(5);

            //assert
            Assert.AreEqual(0, DreamDataContainer.Items.Count);
        }

        [TestMethod]
        public void RemoveDream_DreamDoesNotExist_Failed()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            iDreamLogic.RemoveDream(4);

            //assert
            Assert.AreEqual(1, DreamDataContainer.Items.Count);
        }

        [TestMethod]
        public void GetDreams_OneDreamInList()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            List<DreamLogicModel> dataDreams = iDreamLogic.GetDreams();

            //assert
            Assert.AreEqual(1, dataDreams.Count);
            Assert.IsNotNull(dataDreams);
        }

        [TestMethod]
        public void GetDreamsByUserId_UserHasDream_Success()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            List<DreamLogicModel> logicDreams = iDreamLogic.GetDreamsByUserId(userId);

            //assert
            Assert.AreEqual(1, logicDreams.Count);
            Assert.IsNotNull(logicDreams);
        }

        [TestMethod]
        public void GetDreamsByUserId_UserHasNoDreams_Failed()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            int requestedUserId = 1;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            List<DreamLogicModel> dataDreams = iDreamLogic.GetDreamsByUserId(requestedUserId);

            //assert
            Assert.AreEqual(0, dataDreams.Count);
            Assert.IsNotNull(dataDreams);
        }

        [TestMethod]
        public void GetDreamById_ExistingDream_Success()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            DreamLogicModel returnDream = iDreamLogic.GetDreamById(id);

            //assert
            Assert.AreEqual(logicDream.Id, returnDream.Id);
            Assert.AreEqual(logicDream.UserId, returnDream.UserId);
            Assert.AreEqual(logicDream.Title, returnDream.Title);
            Assert.AreEqual(logicDream.Story, returnDream.Story);
            Assert.AreEqual(logicDream.CreationDateTime, returnDream.CreationDateTime);
            Assert.IsNotNull(returnDream);
        }

        [TestMethod]
        public void GetDreamById_NonExistingDream_ReturnsNull()
        {
            //arrange
            DreamMemData dreamMemData = new();
            IDreamData dreamConnector = dreamMemData;
            DreamLogic dreamLogic = new(dreamConnector);
            IDreamLogic iDreamLogic = dreamLogic;
            DreamDataContainer.Items.Clear();

            int id = 5;
            int requestedId = 4;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);
            DreamDataModel dataDream = DreamDataMapper.DreamConnectorToDataModel(conDream);
            DreamDataContainer.Items.Add(dataDream);

            //act
            DreamLogicModel returnDream = iDreamLogic.GetDreamById(requestedId);

            //assert
            Assert.IsNull(returnDream);
        }
    }
}
