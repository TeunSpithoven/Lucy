using System.Linq;
using Data.Containers;
using Data.Models;
using Logic.Factories;
using Logic.Interfaces;
using Logic.Mappers;
using Logic.Models;
using LogicDataConnector.Factories;
using LogicDataConnector.Interfaces;
using LogicDataConnector.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Logic
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
            IDreamConnector dreamData = dataFactory.DreamMemData();
            DreamDataContainer.Items.Clear();

            int id = 5;
            int userId = 2;
            string title = "Title of the test logicDream";
            string story = "Story of the test logicDream";
            DreamLogicModel logicDream = new(id, userId, title, story);
            DreamConnectorModel conDream = DreamLogicMapper.LogicToConnectorDreamModel(logicDream);

            IDreamLogic dreamLogic = logicFactory.DreamLogic(dreamData);

            //act
            dreamLogic.AddDream(logicDream);

            //assert
            int amountOfDreamsInMemory = DreamDataContainer.Items.Count;
            Assert.AreNotEqual(0, amountOfDreamsInMemory);

            DreamDataModel firstDreamInMemory = DreamDataContainer.Items.First();

            Assert.AreEqual(conDream.Id, firstDreamInMemory.Id);
            Assert.AreEqual(conDream.UserId, firstDreamInMemory.UserId);
            Assert.AreEqual(conDream.Title, firstDreamInMemory.Title);
            Assert.AreEqual(conDream.Story, firstDreamInMemory.Story);
        }
    }
}
