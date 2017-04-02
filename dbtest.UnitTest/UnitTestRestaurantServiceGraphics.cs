using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;
using dbtest.Util;

namespace dbtest.UnitTest
{
    [TestClass]
    public class UnitTestRestaurantServiceGraphics
    {
        [TestMethod]
        public void TestMethodServiceVote1()
        {
            var client = NewServiceClient.InstanceService();

            client.VoteInRestaurant("Teste", 50);

            var restaurantsVotedToday = client.GetRestaurantVotedToday();

            Assert.IsTrue(restaurantsVotedToday.Length > 0);
        }
    }
}
