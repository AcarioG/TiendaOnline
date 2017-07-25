using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Shop;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class CarritoComprasController : Controller
    {
        Shopstore storeDB = new Shopstore();
        // GET: CarritoCompras
        public ActionResult Index()
        {
            

                var carrito = CarritoCompras.GetCart(this.HttpContext);


                var viewModel = new CarritoComprasModel
                {
                    ItemCarrito = carrito.GetCartItems(),
                    CarritoTotal = carrito.GetTotal()
                };

                return View(viewModel);
            }

        public ActionResult AddToCart(int id)
        {

            var addedItem = storeDB.Items
                .Single(item => item.ItemId == id);

            var carrito = CarritoCompras.GetCart(this.HttpContext);

            carrito.AddToCart(addedItem);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoverCarrito(int id)
        {

            var carrito = CarritoCompras.GetCart(this.HttpContext);


            string itemName = storeDB.Carrito
                .Single(Item => Item.RegistroId == id).Item.Titulo;


            int itemCount = carrito.RemoveFromCart(id);


            var results = new EliminarCarritoCompraModel
            {
                Mensaje = Server.HtmlEncode(itemName) +
                    " se ha removido del carrito de compras.",
                CarritoTotal = carrito.GetTotal(),
                CartCount = carrito.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var carrito = CarritoCompras.GetCart(this.HttpContext);

            ViewData["CartCount"] = carrito.GetCount();
            return PartialView("CartSummary");
        }
    }
}


