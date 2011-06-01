using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L.PX.Core.Data;
using System.Web.Security;

namespace L.PX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "L.PX " + User.Identity.Name;

            var dao = new LpxDao();
            var membershipUser = Membership.GetUser(User.Identity.Name);
            if (membershipUser != null)
                dao.Users.Single(u => u.Email == membershipUser.Email);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
