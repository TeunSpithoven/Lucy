using System;
using System.Collections.Generic;
using System.Linq;
using Data.Containers;
using Data.Factories;
using Data.Interfaces;
using Data.Models;
using Logic.Factories;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class DreamLogicTest
    {
        [TestMethod]
        public void AddDream_AllFieldsFilled_Success()
        {
            //arrange
            DreamLogicFactory logicFactory = new();
            DreamDataFactory dataFactory = new();
            IDreamData dreamData = dataFactory.DreamMemData();
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamDataModel dataDream = DreamLogicMapper.LogicToDataDreamModel(logicDream);

            IDreamLogic dreamLogic = logicFactory.DreamLogic(dreamData);

            //act
            dreamLogic.AddDream(logicDream);

            //assert
            int amountOfDreamsInMemory = DreamDataContainer.Items.Count;
            Assert.AreNotEqual(0, amountOfDreamsInMemory);

            DreamDataModel firstDreamInMemory = DreamDataContainer.Items.First();

            Assert.AreEqual(dataDream.Id, firstDreamInMemory.Id);
            Assert.AreEqual(dataDream.UserId, firstDreamInMemory.UserId);
            Assert.AreEqual(dataDream.Title, firstDreamInMemory.Title);
            Assert.AreEqual(dataDream.Story, firstDreamInMemory.Story);
        }
    }
}
