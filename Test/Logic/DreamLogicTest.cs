using System.Linq;
using Data.Containers;
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
    public class DreamLogicTest
    {
        [TestMethod]
        public void AddDream_Success()
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
    }
}
