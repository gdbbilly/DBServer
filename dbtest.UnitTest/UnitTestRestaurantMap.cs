using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;

namespace dbtest.UnitTest
{
    [TestClass]
    public class UnitTestRestaurantMap
    {
        [TestMethod]
        public void TestMethodRestaurantMapFindAll()
        {
            Assert.IsTrue(RestaurantMap.Instance.FindAll().Count > 0);
        }

        [TestMethod]
        public void TestMethodRestaurantMapFindId()
        {
            Assert.IsNotNull(RestaurantMap.Instance.FindById(1));
        }

        [TestMethod]
        public void TestMethodRestaurantMapCount()
        {
            Assert.IsTrue(RestaurantMap.Instance.Count() > 0);
        }

        [TestMethod]
        public void TestMethodRestaurantMapFindAllNotVotedWeek()
        {
            Assert.IsTrue(RestaurantMap.Instance.FindAllNotVotedWeek().Count > 0);
        }

        [TestMethod]
        public void TestMethodRestaurantMapFindAllVotedWeek()
        {
            Assert.IsTrue(RestaurantMap.Instance.FindAllVotedWeek().Count >= 0);
        }

        [TestMethod]
        public void TestMethodRestaurantMapRestaurantWithoutVotesToday()
        {
            Assert.IsTrue(RestaurantMap.Instance.RestaurantWithoutVotesToday().Count >= 0);
        }

        [TestMethod]
        public void TestMethodRestaurantMapVotingClosed()
        {
            Assert.IsNotNull(RestaurantMap.Instance.VotingClosed());
        }
    }
}
 