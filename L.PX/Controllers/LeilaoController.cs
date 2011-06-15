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
        static LpxDao leilaoDB = new LpxDao();
        Leilao leilao = leilaoDB.Leiloes.First();

        //
        // GET: /Leilao/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            var email = Membership.GetUser().Email;
            var usuario = leilaoDB.Users.Single(u => u.Email == email);

            var participante = leilao.FindParticipante(usuario);

            if ((participante != null) && (participante.IsContratante == false))
            {
                return RedirectToAction("TelaParticipante");
            }

            if ((participante != null) && (participante.IsContratante == true))
            {
                return RedirectToAction("TelaContratante");
            }

            return View();
        }


        //
        // GET: /Gerenciar Leilao/

        public ActionResult GerenciarLeilao()
        {

            var email = Membership.GetUser().Email;
            var usuario = leilaoDB.Users.Single(u => u.Email == email);

            var participante = leilao.FindParticipante(usuario);

            if ((participante != null) && (participante.IsContratante == true))
                return RedirectToAction("TelaGerenciador");
            else
                return RedirectToAction("TelaGerenciadorPart");

            return View();

        }


        //GET: TelaParticipante/
        public ActionResult TelaParticipante()
        {
            var email = Membership.GetUser().Email;
            var usuario = leilaoDB.Users.Single(u => u.Email == email);
            var lance = Lance.Build(10, leilao.NumeroDeLotes, usuario);

            ViewBag.Lances = leilao.ListaLancesDosUsuarios().Where(l => l.Lance.User == usuario);
            return View(lance);
        }

        [HttpPost]
        public ActionResult TelaParticipante(Lance lance)
        {
            TryUpdateModel(lance);

            var email = Membership.GetUser().Email;
            var usuario = leilaoDB.Users.Single(u => u.Email == email);
            lance.User = usuario;
            var lanceProcessado = leilao.RecebeLance(lance);

            ViewBag.Lances = leilao.ListaLancesDosUsuarios().Where(l => l.Lance.User == usuario);
            return View();
        }




        //Get: TelaContratante/
        public ActionResult TelaContratante()
        {
            ViewBag.Participantes = leilaoDB.Participantes.Include("Usuario").Where(p => p.Leilao.Id == leilao.Id);
            return View(leilao);
        }

        [HttpPost]
        public ActionResult TelaContratante(Lance lance)
        {
            // Membership.GetUser().IsOnline();
            return View();
        }


        //Get: TelaGerenciador/
        public ActionResult TelaGerenciador()
        {

            return View();

        }

        [HttpPost]
        public ActionResult TelaGerenciador(Leilao leilao)
        {
            if (ModelState.IsValid)
            {
                leilaoDB.Leiloes.Add(leilao);
                leilaoDB.SaveChanges();
                return RedirectToAction("TelaGerenciador");
            }
            return View(leilao);
        }

        //Get: TelaGerenciadorPart/
        public ActionResult TelaGerenciadorPart()
        {
            ViewBag.Participantes = leilaoDB.Participantes.Include("Usuario").Where(p => p.Leilao.Id == leilao.Id);
            return View(leilao);
        }

        [HttpPost]
        public ActionResult TelaGerenciadorPart(Leilao leilao)
        {
            return RedirectToAction("TelaParticipante");
            return View(leilao);
        }


    }
}
