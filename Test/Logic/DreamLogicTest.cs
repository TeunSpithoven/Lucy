using DataInterface.Models;
using Logic;
using Logic.Mappers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Test.Data;

namespace Test.Logic
{
    [TestClass]
    public class DreamLogicTest
    {
        [TestMethod]
        public void Create()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";

            //act
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(dreamLogic.Create(userId, title, story));

            //assert
            int amountOfDreamsInMemory = DreamTestData.Items.Count;
            Assert.AreNotEqual(0, amountOfDreamsInMemory);

            DreamDataModel firstDreamInMemory = DreamTestData.Items.First();

            Assert.IsNotNull(dataDream.Id);
            Assert.AreEqual(dataDream.UserId, firstDreamInMemory.UserId);
            Assert.AreEqual(dataDream.Title, firstDreamInMemory.Title);
            Assert.AreEqual(dataDream.Story, firstDreamInMemory.Story);
        }

        [TestMethod]
        public void RemoveDream_DreamExists_Success()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            int returnInt = dreamLogic.RemoveDream(5);

            //assert
            Assert.AreEqual(5, returnInt);
        }

        [TestMethod]
        public void RemoveDream_DreamDoesNotExist_Failed()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            int returnInt = dreamLogic.RemoveDream(4);

            //assert
            Assert.AreEqual(-1, returnInt);
        }

        [TestMethod]
        public void GetDreams_OneDreamInList()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            List<DreamLogicModel> dataDreams = dreamLogic.GetDreams();

            //assert
            Assert.AreEqual(1, dataDreams.Count);
            Assert.IsNotNull(dataDreams);
        }

        [TestMethod]
        public void GetDreamsByUserId_UserHasDream_Success()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            List<DreamLogicModel> logicDreams = dreamLogic.GetDreamsByUserId(userId);

            //assert
            Assert.AreEqual(1, logicDreams.Count);
            Assert.IsNotNull(logicDreams);
        }

        [TestMethod]
        public void GetDreamsByUserId_UserHasNoDreams_Failed()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            int requestedUserId = 1;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            List<DreamLogicModel> dataDreams = dreamLogic.GetDreamsByUserId(requestedUserId);

            //assert
            Assert.AreEqual(0, dataDreams.Count);
            Assert.IsNotNull(dataDreams);
        }

        [TestMethod]
        public void GetDreamById_ExistingDream_Success()
        {
            //arrange
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            DreamLogicModel returnDream = dreamLogic.GetDreamById(id);

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
            DreamTestData dreamMemData = new();
            CommentTestData commentMemData = new();
            DreamLogic dreamLogic = new(dreamMemData, commentMemData);
            DreamTestData.Items.Clear();

            int id = 5;
            int requestedId = 4;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);
            DreamTestData.Items.Add(dataDream);

            //act
            DreamLogicModel returnDream = dreamLogic.GetDreamById(requestedId);

            //assert
            Assert.IsNull(returnDream);
        }
    }
}