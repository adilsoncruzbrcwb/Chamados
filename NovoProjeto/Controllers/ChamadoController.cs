using NovoProjeto.Contexts;
using NovoProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NovoProjeto.Controllers
{
    public class ChamadoController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Chamado
        public ActionResult Index()
        {
            return View(context.Chamados.OrderBy(c => c.NomeChamado));
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chamado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chamado chamado)
        {
            context.Chamados.Add(chamado);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamados = context.Chamados.Find(id);
            if (chamados == null)
            {
                return HttpNotFound();
            }
            return View(chamados);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(chamado).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chamado);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = context.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Chamado chamado = context.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Chamado chamados = context.Chamados.Find(id);
            context.Chamados.Remove(chamados);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + chamados.NomeChamado.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}
