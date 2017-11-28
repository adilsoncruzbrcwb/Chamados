using Newtonsoft.Json;
using NovoProjeto.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NovoProjeto.Models
{
    public class FuncionarioController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Funcionario
        public ActionResult Index()
        {
            return View(context.Funcionarios.OrderBy(c => c.Nome));
        }
        // GET: Chamado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chamado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario pFuncionario)
        {
            context.Funcionarios.Add(pFuncionario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionarios = context.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Funcionario funcionarios)
        {
            if (ModelState.IsValid)
            {
                context.Entry(funcionarios).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarios);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = context.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = context.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Funcionario funcionario = context.Funcionarios.Find(id);
            context.Funcionarios.Remove(funcionario);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + funcionario.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}
