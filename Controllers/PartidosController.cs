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
    public class PartidosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Partidos
        public ActionResult Index()
        {
            return View(db.Partidos.ToList());
        }
        public ActionResult IndexCopa()
        {
            var consulta = (from consultaa in db.Partidos where consultaa.torneo == "Copa America" select consultaa).ToList();
            var id_usuario = User.Identity.GetUserId().ToString();
            var consulta2 = (from consultaa2 in db.marcadorUsers select consultaa2).ToList();
            List < Partido > partidos = new List<Partido>();
            var crear = false;

            foreach(var item in consulta)
            {
                crear = false;
                if (consulta2.Count != 0)
                {
                    foreach (var item2 in consulta2)
                    {
                        if (item.id == item2.id_partido)
                        {
                            if (item2.id_user == User.Identity.GetUserId().ToString())
                            {
                                crear = false;
                                break;
                            }
                            else
                            {
                                crear = true;
                                break;
                            }
                        }
                        else
                        {
                            crear = true;
                        }
                    }
                    if(crear == true)
                    {
                        Partido partido = new Partido();
                        partido.id = item.id;
                        partido.torneo = item.torneo;
                        partido.horaUno = item.horaUno;
                        partido.horaDos = item.horaDos;
                        partido.grupo = item.grupo;
                        partido.equipoUno = item.equipoUno;
                        partido.equipoDos = item.equipoDos;

                        partidos.Add(partido);
                        item.id = 0;

                    }
                }
                else
                {
                    Partido partido = new Partido();
                    partido.id = item.id;
                    partido.torneo = item.torneo;
                    partido.horaUno = item.horaUno;
                    partido.horaDos = item.horaDos;
                    partido.grupo = item.grupo;
                    partido.equipoUno = item.equipoUno;
                    partido.equipoDos = item.equipoDos;

                    partidos.Add(partido);
                }
            }
            
            return View(partidos);
        }
        //            {
        //        var query = (from ur in db.marcadorUsers
        //                     join u in db.Partidos on ur.id_partido equals u.id

        //                     select new Marcadoresusuarios
        //                     {
        //                         id = u.id,
        //                         id_user = ur.id_user,
        //                         id_torneo = ur.id_torneo,
        //                         grupo = u.grupo,
        //                         resultadoUno = ur.resultadoUno,
        //                         resultadoDos = ur.resultadoDos,
        //                         equipoUno = u.equipoUno,
        //                         equipoDos = u.equipoDos
        //                     }).ToList();
        //        return View(query);
        //}


        // GET: Partidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partidos.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partidos/Create
        public ActionResult Create()
        {
            PartidosDatos partidosDatos = new PartidosDatos();
            partidosDatos.equipos = db.Equipos.ToList();
            partidosDatos.torneos = db.Torneos.ToList();
            return View(partidosDatos);
        }

        // POST: Partidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,equipoUno,equipoDos,torneo,horaUno,horaDos,grupo")] Partido partido)
        {
            
            if (ModelState.IsValid)
            {
                Convert.ToDateTime(partido.horaUno);
                Convert.ToDateTime(partido.horaDos);

                db.Partidos.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partido);
        }

        // GET: Partidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partidos.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            PartidosDatos partidosDatos = new PartidosDatos();
            partidosDatos.id = partido.id;
            partidosDatos.torneo = partido.torneo;
            partidosDatos.equipoDos = partido.equipoDos;
            partidosDatos.equipoUno = partido.equipoUno;
            partidosDatos.grupo = partido.grupo;
            partidosDatos.horaUno = partido.horaUno;
            partidosDatos.horaDos = partido.horaDos;
            partidosDatos.equipos = db.Equipos.ToList();
            partidosDatos.torneos = db.Torneos.ToList();
            return View(partidosDatos);
        }

        // POST: Partidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,equipoUno,equipoDos,torneo,horaUno,horaDos,grupo")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partido);
        }

        // GET: Partidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partidos.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partido partido = db.Partidos.Find(id);
            db.Partidos.Remove(partido);
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
