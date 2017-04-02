using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;
using dbtest.Exceptions;
using dbtest.Methods;

namespace dbtest.UnitTest
{
    [TestClass]
    public class AutomaticTestUser2
    {
        [TestMethod]
        public void TestMethodUser2()
        {
            try
            {
                var list1 = RestaurantMethods.GetRestaurantsVotedWeek();

                RestaurantMethods.Vote("automaticUser111", 1);
                RestaurantMethods.Vote("automaticUser112", 1);
                
                RestaurantMethods.CloseVoting();

                var list2 = RestaurantMethods.GetRestaurantsVotedWeek();

                Assert.IsTrue(list1.Count != list2.Count);
            }
            catch (BusinessException)
            {
                
            }
        }
    }
}
 