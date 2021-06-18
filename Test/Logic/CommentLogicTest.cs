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
        public void Create_NegativeUserId_ThrowsException()
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

        [TestMethod]
        public void GetByUserId_6_Success()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();
            CommentTestData.Items.Add(new CommentDataModel(2, 6, "test1"));
            CommentTestData.Items.Add(new CommentDataModel(55, 6, "test2"));
            CommentTestData.Items.Add(new CommentDataModel(444, 6, "test3"));

            List<CommentLogicModel> returnComments = commentLogic.GetByUserId(6);

            Assert.AreEqual(3, returnComments.Count);
            Assert.IsTrue(returnComments.Exists(x => x.Id == 2));
            Assert.IsTrue(returnComments.Exists(x => x.Id == 55));
            Assert.IsTrue(returnComments.Exists(x => x.Id == 444));
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Validation for Commentlogic GetByUserId failed.")]
        public void GetByUserId_minus7_ThrowsException()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();

            commentLogic.GetByUserId(-7);
        }

        [TestMethod]
        public void GetById_3_Success()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();
            CommentTestData.Items.Add(new CommentDataModel(3, 69696969, "test1"));

            CommentLogicModel returnComment = commentLogic.GetById(3);

            Assert.IsNotNull(returnComment);
            Assert.AreEqual(returnComment.UserId, 69696969);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Validation for Commentlogic GetById failed.")]
        public void GetById_negative4_ThrowsException()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();

            commentLogic.GetById(-4);
        }

        [TestMethod]
        public void GetByDreamId_5_Success()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();
            CommentTestData.Items.Add(new CommentDataModel(2, 5, "test1"));
            CommentTestData.Items.Add(new CommentDataModel(55, 5, "test2"));
            CommentTestData.Items.Add(new CommentDataModel(444, 6, "test3"));

            List<CommentLogicModel> returnComments = commentLogic.GetByDreamId(5);

            Assert.AreEqual(2, returnComments.Count);
            Assert.IsTrue(returnComments.Exists(x => x.Id == 55));
            Assert.IsTrue(returnComments.Exists(x => x.Id == 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Validation for Commentlogic GetByDreamId failed.")]
        public void GetByDreamId_minus3_ThrowsException()
        {
            CommentTestData commentData = new();
            CommentLogic commentLogic = new(commentData);
            CommentTestData.Items.Clear();

            commentLogic.GetByDreamId(-3);
        }
    }
}
