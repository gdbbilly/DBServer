using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;
using dbtest.Exceptions;

namespace dbtest.UnitTest
{
    [TestClass]
    public class AutomaticTestUser1
    {
        [TestMethod]
        public void TestMethodVote1()
        {
            try
            {
                RestaurantSettingsMap.Instance.Vote("automaticUser1", 1);

                RestaurantSettingsMap.Instance.Vote("automaticUser2", 2);

                RestaurantSettingsMap.Instance.Vote("automaticUser2", 2);
            }
            catch (BusinessException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestMethodVote2()
        {
            try
            {
                RestaurantSettingsMap.Instance.Vote("automaticUser11", 1);

                RestaurantSettingsMap.Instance.Vote("automaticUser12", 2);
                
                Assert.IsTrue(true);
            }
            catch (BusinessException)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
 