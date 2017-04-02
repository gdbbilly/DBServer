using dbtest.Exceptions;
using dbtest.Util;
using System;
using System.Linq;
using System.Web.Mvc;

namespace dbtest.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            bool isAdmin = false;
            if (HttpContext != null && HttpContext.User != null)
            {
                isAdmin = HttpContext.User.Identity.Name.Equals("admin", StringComparison.InvariantCultureIgnoreCase);
            }

            return PartialView(isAdmin);
        }

        public ActionResult DateTimeWeek()
        {
            return PartialView();
        }

        public ActionResult RestaurantsCount()
        {
            
            var client = NewServiceClient.InstanceService();

            return PartialView(client.GetRestaurantsCount());
        }

        public ActionResult Administration()
        {
            try
            {
                var client = NewServiceClient.InstanceService();
                return PartialView(client.VotingClosed());
            }
            catch (BusinessException e)
            {
                return PartialView(false);
            }
        }

        public ActionResult CountUsersWithVotes()
        {
            try
            {
                var client = NewServiceClient.InstanceService();
                return PartialView(client.UsersWithTodayVote().Count());
            }
            catch (BusinessException e)
            {
                return PartialView(false);
            }
        }

        public ActionResult NameHeader()
        {

            return PartialView((object)HttpContext.User.Identity.Name);
        }

        public JsonResult CloseVotingHandler()
        {
            try
            {
                var client = NewServiceClient.InstanceService();
                client.CloseVoting();
                
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (BusinessException e)
            {
                return Json(e.ExceptionMessage, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Retorna o tempo para atualizar a tela
        /// </summary>
        /// <returns>tempo em milisegundos</returns>
        [HttpPost]
        public int GetTime()
        {
            var valor = 5 * 60000;

            return valor;
        }

    }
}
