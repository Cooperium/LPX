using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L.PX.Core;
using L.PX.Core.Data;
using System.Web.Security;


namespace L.PX.Controllers
{
    public class LeilaoController : Controller
    {
        LpxDao leilaoDB = new LpxDao();

        //
        // GET: /Leilao/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var leilao = leilaoDB.Leiloes.First();
            var email = Membership.GetUser().Email;
            var usuario = leilaoDB.Users.Single(u => u.Email == email);

            var participante = leilao.FindParticipante(usuario);

            if ((participante != null) && (participante.IsContratante  == false))
                 {
                     return RedirectToAction("TelaParticipante");
                 }
            
                if ((participante != null) && (participante.IsContratante  == true))
                {
                    return RedirectToAction("TelaContratante");
                }


            return View();
        }

        //Post: TelaParticipante/
        public ActionResult TelaParticipante()
        {
            return View();

        }

        //Get: TelaContratante/
           public ActionResult TelaContratante()
          {
            return View();
         }

    }
}
