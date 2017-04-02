using dbtest.Entities;
using dbtest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbtest.Mvc.Controllers
{
    public class GraphicsController : Controller
    {
        public ActionResult GraphicRestaurantVoted()
        {
            return PartialView(LoadRestaurantVotedData());
        }

        [HttpPost]
        public JsonResult RestaurantVoted()
        {
            return Json(LoadRestaurantVotedData());
        }

        public ActionResult GraphicAmountVotesRestaurant()
        {
            return PartialView(LoadAmountVotesRestaurant());
        }

        [HttpPost]
        public JsonResult AmountVotesRestaurant()
        {
            return Json(LoadAmountVotesRestaurant());
        }

        public ActionResult GraphicMostVotedInWeek()
        {
            return PartialView(LoadMostVotedInWeek());
        }

        [HttpPost]
        public JsonResult MostVotedInWeek()
        {
            return Json(LoadMostVotedInWeek());
        }

        private List<DataJson> LoadMostVotedInWeek()
        {
            var list = new List<DataJson>();

            var client = NewServiceClient.InstanceService();
            var restaurantsVotedToday = client.GetRestaurantsVotedWeek();

            foreach (var item in restaurantsVotedToday)
            {
                list.Add(new DataJson
                {
                    Name = item.Name,
                    Value = item.Votes
                });
            }
            if (list.Count == 0)
                list.Add(new DataJson { Name = "Existentes no período", Value = 0 });

            return list;
        }

        private List<DataJson> LoadAmountVotesRestaurant()
        {
            var list = new List<DataJson>();

            var client = NewServiceClient.InstanceService();
            var restaurantsVotedToday = client.GetRestaurantVotedToday();
            foreach (var item in restaurantsVotedToday)
            {
                list.Add(new DataJson
                {
                    Name = item.Name,
                    Value = item.Votes
                });
            }

            if (list.Count == 0)
                list.Add(new DataJson { Name = "Existentes no período", Value = 0 });

            return list;
        }

        private List<DataJson> LoadRestaurantVotedData()
        {
            var list = new List<DataJson>();

            var client = NewServiceClient.InstanceService();

            var restaurantsVotedToday = client.GetRestaurantVotedToday().Count();
            var restaurantsNotVotedToday = client.GetRestaurantsNotVotedToday().Count();


            list.Add(new DataJson
            {
                Name = "Votados hoje",
                Value = restaurantsVotedToday
            });

            list.Add(new DataJson
            {
                Name = "Não votados hoje",
                Value = restaurantsNotVotedToday
            });


            if (list.Count == 0)
                list.Add(new DataJson { Name = "Existentes no período", Value = 0 });

            return list;
        }
    }
}
