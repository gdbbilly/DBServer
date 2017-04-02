using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;


namespace dbtest.UnitTest
{
    [TestClass]
    public class UnitTestRestaurantSettingsMap
    {
        [TestMethod]
        public void TestMethodRestaurantMapFindAll()
        {
            bool success = true;
            RestaurantSettingsMap.Instance.Vote("usuário votador 1", 11);

            if (RestaurantSettingsMap.Instance.RestaurantWithVotesToday().Count <= 0)
                success = false;
            
            var users = RestaurantSettingsMap.Instance.UsersWithTodayVote();
            if (!users.Contains("usuário votador 1"))
                success = false;

            success = RestaurantSettingsMap.Instance.UserWithTodayVote("usuário votador 1");

            if (RestaurantSettingsMap.Instance.UserVote("usuário votador 1") != 11)
                success = false;

            Assert.IsTrue(success);
        }
    }
}
