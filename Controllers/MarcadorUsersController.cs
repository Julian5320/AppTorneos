using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTorneos.Models;
using AppTorneos.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace AppTorneos.Controllers
{
    public class MarcadorUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MarcadorUsers
        public ActionResult Index()
        {
            var query = (from ur in db.marcadorUsers
                         join u in db.Partidos on ur.id_partido equals u.id

                         select new Marcadoresusuarios
                         {
                             id = ur.id,
                             id_user = ur.id_user,
                             id_torneo = ur.id_torneo,
                             grupo = u.grupo,
                             resultadoUno = ur.resultadoUno,
                             resultadoDos = ur.resultadoDos,
                             equipoUno = u.equipoUno,
                             equipoDos = u.equipoDos,

                           
                         }).ToList();
            return View(query);

        }

        // GET: MarcadorUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcadorUser marcadorUser = db.marcadorUsers.Find(id);
            if (marcadorUser == null)
            {
                return HttpNotFound();
            }
            return View(marcadorUser);
        }

        // GET: MarcadorUsers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: MarcadorUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Create(string[] resultado1, string[] resultado2, string[] torneo, int[] idPartido)
        {
            MarcadorUser marcadorUser = new MarcadorUser();
            if (ModelState.IsValid)
            {

                for (var i=0; i < resultado1.Length; i++) {
                if (resultado1[i] != "" && resultado2[i] != "")
                {
                marcadorUser.resultadoUno = Int32.Parse(resultado1[i]);
                marcadorUser.resultadoDos = Int32.Parse(resultado2[i]);
                marcadorUser.id_torneo = torneo[i];
                marcadorUser.id_partido = idPartido[i];
                marcadorUser.id_user = User.Identity.GetUserId().ToString();

                db.marcadorUsers.Add(marcadorUser);
                db.SaveChanges();
                    }
                }
                db.SaveChanges();
                return RedirectToAction("IndexCopa","Partidos");
            }

            return View(marcadorUser);
        }

        // GET: MarcadorUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcadorUser marcadorUser = db.marcadorUsers.Find(id);
            if (marcadorUser == null)
            {
                return HttpNotFound();
            }
            return View(marcadorUser);
         }

        // POST: MarcadorUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,resultadoUno,resultadoDos")] MarcadorUser marcadorUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcadorUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcadorUser);
        }

        // GET: MarcadorUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcadorUser marcadorUser = db.marcadorUsers.Find(id);
            if (marcadorUser == null)
            {
                return HttpNotFound();
            }
            return View(marcadorUser);
        }

        // POST: MarcadorUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcadorUser marcadorUser = db.marcadorUsers.Find(id);
            db.marcadorUsers.Remove(marcadorUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
