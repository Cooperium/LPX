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
    public class LeilãoController : Controller
    {
        LpxDao leilaoDB = new LpxDao();
         
        //
        // GET: /Leilão/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var leilao = leilaoDB.Leiloes.First();
            var usuario = leilaoDB.Users.Single(u => u.Email == Membership.GetUser().Email);

            var participante = leilao.FindParticipante(usuario);

            if ((participante != null) && (participante.papel == Papel.Participante))
            {
                return RedirectToAction("TelaParticipante");            
            }
            else
            if ((participante != null) && (participante.papel == Papel.Contratante))
            {
                return RedirectToAction("","");
            }
            

            //var email = Membership.GetUser(User.Identity.Name).Email;
            //var email2 = Membership.GetUser(User.Identity.Name).Email;

            
            //var usuario2 = leilaoDB.Users.Single(u => u.Email == email2);

            //var participante1 = Participante.Build(usuario,Papel.Contratante);
            //var participante2 = Participante.Build(usuario2,Papel.Participante);

            //if(participante2.papel == Papel.Participante)
            //{
            
            
            //}
            //else
            //{
            
            //}
            //var leilao = leilaoDB.Leilao.First();
            //var email = Membership.GetUser(User.Identity.Name).Email;
            //var usuario = leilaoDB.Users.Single(u => u.Email == email);
            
            

            

            
            return View();
        }

        //public ActionResult TelaParticipante()
        //{ }
    }
}
