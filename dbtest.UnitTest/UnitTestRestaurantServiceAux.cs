using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;
using dbtest.Util;

namespace dbtest.UnitTest
{
    [TestClass]
    public class UnitTestRestaurantServiceAux
    {
        [TestMethod]
        public void TestMethodServiceRestaurantToday2()
        {
            var client = NewServiceClient.InstanceService();
            for (int i = 1; i <= 50; i++)
            {
                for (int x = 1 * i; x <= 50; x++)
                {
                    if (x % 2 == 0)
                    {
                        client.VoteInRestaurant(string.Format("rodrigo{0}", x), i);
                    }
                    else
                    {
                        client.VoteInRestaurant(string.Format("rodrigo{0}", x), 5);
                    }
                }
            }

            //client.CloseVoting();

            var restId = client.GetRestaurantWinnerToday();
            var closed = client.VotingClosed();

            Assert.IsTrue(restId.Id == 5 && !closed);
        }

        [TestMethod]
        public void TestMethodServiceRestaurantToday3()
        {
            var client = NewServiceClient.InstanceService();
            var restId = client.GetRestaurantWinnerToday();

            Assert.IsTrue(restId.Id == 5);

        }
    }
}
