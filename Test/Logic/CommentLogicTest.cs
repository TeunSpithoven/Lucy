using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataInterface.Models;
using Logic;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Data;

namespace Test.Logic
{
    [TestClass]
    public class CommentLogicTest
    {
        [TestMethod]
        public void Create_Success()
        {
            CommentTestData commentData = new CommentTestData();
            CommentLogic commentLogic = new(commentData);
            int userId = 3;
            string message = "test";
            int dreamId = 4;

            CommentLogicModel returnComment = commentLogic.Create(userId, message, dreamId);

            Assert.IsNotNull(returnComment.Id);
            Assert.AreEqual(3, returnComment.UserId);
            Assert.AreEqual("test", returnComment.Message);
            Assert.AreEqual(4, returnComment.DreamId);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "CommentLogic Create validation failed")]
        public void Create_NegativeUserId_Failed()
        {
            CommentTestData commentData = new CommentTestData();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();

            commentLogic.Create(-4, "test", 3);
        }
    

        [TestMethod]
        public void GetAll_OneCommentExists_ReturnsOneComment()
        {
            CommentTestData commentData = new CommentTestData();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();
            CommentTestData.Items.Add(new CommentDataModel(3, 5, "test", 44));

            List<CommentLogicModel> returnList = commentLogic.GetAll();

            Assert.AreEqual(1, returnList.Count);
            Assert.AreEqual(3, returnList[0].Id);
        }

        [TestMethod]
        public void GetAll_NoCommentExists_ReturnsNoComments()
        {
            CommentTestData commentData = new CommentTestData();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();

            List<CommentLogicModel> returnList = commentLogic.GetAll();

            Assert.AreEqual(0, returnList.Count);
        }
    }
}
