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
            Assert.IsTrue(RestaurantMap.Instance.FindAllVotedWeek(GetFirstDayofWeek(DateTime.Now), GetLastDayofWeek(DateTime.Now)).Count >= 0);
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

        private static DateTime GetFirstDayofWeek(DateTime date)
        {
            int lessNumber = 1;

            return date.AddDays(lessNumber - date.DayOfWeek.GetHashCode());
        }

        private static DateTime GetLastDayofWeek(DateTime date)
        {
            int GreateNumber = 7;

            return date.AddDays(GreateNumber - date.DayOfWeek.GetHashCode());
        }
    }
}
 