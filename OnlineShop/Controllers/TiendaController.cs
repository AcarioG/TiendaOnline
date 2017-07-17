using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Shop;

namespace OnlineShop.Controllers
{
    public class TiendaController : Controller
    {
        Shopstore tiendaDB = new Shopstore();
        // GET: Items

        public ActionResult Index()
        {
            var categoria = tiendaDB.Categoria.ToList();
            
            return View(categoria);
        }

        public ActionResult Buscar (string Categoria)
        {
            var Category = tiendaDB.Categoria.Include("Items")
                .Single(c => c.Nombre == Categoria);
            return View(Category);
        }

        // GET: Items/Details/5
        public ActionResult Detalles(int id)
        {
            var item = new Items { Titulo = "item" + id };
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
