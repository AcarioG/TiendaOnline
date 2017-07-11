using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Shop;

namespace OnlineShop.Controllers
{
    public class AdministracionTiendaController : Controller
    {
        private Shopstore db = new Shopstore();

        // GET: AdministracionTienda
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Categoria).Include(i => i.Procductor);
            return View(items.ToList());
        }

        // GET: AdministracionTienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: AdministracionTienda/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaID", "Name");
            ViewBag.ProductorId = new SelectList(db.Productor, "ProductorId", "Name");
            return View();
        }

        // POST: AdministracionTienda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CategoriaId,ProductorId,Titulo,Precio,ItemArtUrl")] Items items)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaID", "Name", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.Productor, "ProductorId", "Name", items.ProductorId);
            return View(items);
        }

        // GET: AdministracionTienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaID", "Name", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.Productor, "ProductorId", "Name", items.ProductorId);
            return View(items);
        }

        // POST: AdministracionTienda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CategoriaId,ProductorId,Titulo,Precio,ItemArtUrl")] Items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaID", "Name", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.Productor, "ProductorId", "Name", items.ProductorId);
            return View(items);
        }

        // GET: AdministracionTienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: AdministracionTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Items items = db.Items.Find(id);
            db.Items.Remove(items);
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
