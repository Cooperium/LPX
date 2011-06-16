using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L.PX.Core;
using L.PX.Models;

namespace L.PX.Controllers
{ 
    public class LeilãoManagerController : Controller
    {
        private LeilaoModelContext db = new LeilaoModelContext();

        //
        // GET: /LeilãoManager/

        public ViewResult Index()
        {
            return View();
        }

        //
        // GET: /LeilãoManager/Details/5


        //
        // GET: /LeilãoManager/Create

        public ActionResult Create()
        {
            ViewBag.Participantes = new SelectList(db.Participante,"Participantes","Email");
            
 
            return View();
        } 

        //
        // POST: /LeilãoManager/Create

        [HttpPost]
        public ActionResult Create(Leilao leilao)
        {
            if (ModelState.IsValid)
            {
                db.Leilaos.Add(leilao);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(leilao);
        }
        
        //
        // GET: /LeilãoManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Leilao leilao = db.Leilaos.Find(id);
            return View(leilao);
        }

        //
        // POST: /LeilãoManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Leilao leilao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leilao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leilao);
        }

        //
        // GET: /LeilãoManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Leilao leilao = db.Leilaos.Find(id);
            return View(leilao);
        }

        //
        // POST: /LeilãoManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Leilao leilao = db.Leilaos.Find(id);
            db.Leilaos.Remove(leilao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}