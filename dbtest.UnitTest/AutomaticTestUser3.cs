using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Map;
using dbtest.Exceptions;
using dbtest.Methods;

namespace dbtest.UnitTest
{
    [TestClass]
    public class AutomaticTestUser3
    {
        [TestMethod]
        public void TestMethodUser3()
        {
            try
            {
                var restaurant = RestaurantMethods.GetRestaurantWinnerToday();

                Assert.IsNotNull(restaurant);
            }
            catch (BusinessException)
            {
                
            }
        }
    }
}
 