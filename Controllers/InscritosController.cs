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

namespace AppTorneos.Controllers
{
    public class InscritosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscritos
        public ActionResult Index()
        {
            return View(db.Inscritos.ToList());
        }

        // GET: Inscritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscritos.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // GET: Inscritos/Create
        public ActionResult Create()
        {
            EquiposYTorneos equiposYTorneos = new EquiposYTorneos();
            equiposYTorneos.torneos = (from torneos in db.Torneos select torneos).ToList();
            equiposYTorneos.equipos = (from torneos in db.Equipos select torneos).ToList();

            return View(equiposYTorneos);
        }

        // POST: Inscritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,equipo,torneo")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                db.Inscritos.Add(inscrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inscrito);
        }

        // GET: Inscritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscritos.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // POST: Inscritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,equipo,torneo")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inscrito);
        }

        // GET: Inscritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscritos.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscrito inscrito = db.Inscritos.Find(id);
            db.Inscritos.Remove(inscrito);
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
