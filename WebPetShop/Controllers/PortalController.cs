using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using AutoMapper;
using WebPetShop.Models;
using Repositories.Repositorios;

namespace WebPetShop.Controllers
{
    public class PortalController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        //private PetShopContext db = new PetShopContext();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());
            return View(mascotaVM);
            //return View(db.Mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascotas.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascota);
        //}

        // GET: Mascotas/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "mascotaID,nombre,edad,fechaNacimiento,estado,foto,fechaAlta")] Mascota mascota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Mascotas.Add(mascota);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(mascota);
        //}

        // GET: Mascotas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascotas.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascota);
        //}

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "mascotaID,nombre,edad,fechaNacimiento,estado,foto,fechaAlta")] Mascota mascota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mascota).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(mascota);
        //}

        // GET: Mascotas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Mascota mascota = db.Mascotas.Find(id);
        //    if (mascota == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascota);
        //}

        // POST: Mascotas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Mascota mascota = db.Mascotas.Find(id);
        //    db.Mascotas.Remove(mascota);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
