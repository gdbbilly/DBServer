using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Util;

namespace dbtest.UnitTest
{
    [TestClass]
    public class UnitTestRestaurantService
    {
        [TestMethod]
        public void TestMethodServiceVote1()
        {
            var client = NewServiceClient.InstanceService();
            client.VoteInRestaurant("rodrigo1", 1);

            var aux = client.ChecksIfUserVote("rodrigo1");

            Assert.IsTrue(aux);
        }

        [TestMethod]
        public void TestMethodServiceVote2()
        {
            var client = NewServiceClient.InstanceService();
            client.VoteInRestaurant("rodrigo2", 2);

            var aux = client.ChecksIfUserVote("rodrigo2");

            Assert.IsTrue(aux);
        }

        [TestMethod]
        public void TestMethodServiceVote3()
        {
            var client = NewServiceClient.InstanceService();

            var aux = client.ChecksIfUserVote("rodrigo300");

            Assert.IsFalse(aux);
        }

        [TestMethod]
        public void TestMethodServiceUsersVotes()
        {
            var client = NewServiceClient.InstanceService();
            var aux = client.UsersWithTodayVote();

            Assert.IsTrue(aux.Length != 0);
        }

        [TestMethod]
        public void TestMethodServiceRestaurantsNotVotedWeek()
        {
            var client = NewServiceClient.InstanceService();
            var aux = client.GetRestaurantsNotVotedWeek();

            Assert.IsTrue(aux.Length != 0);
        }

        private string GetUser()
        {
            return string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
        }
    }
}
