using OnlineShop.Shop;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class RevisionController : Controller
    {
        Shopstore db = new Shopstore();
        const string PromoCode = "Free";

        // GET: Revision
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Orden();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Usuario = User.Identity.Name;
                    order.DiaOrden = DateTime.Now;


                    db.Orden.Add(order);
                    db.SaveChanges();

                    var carrito = CarritoCompras.GetCart(this.HttpContext);
                    carrito.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {

                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {

            bool isValid = db.Orden.Any(
                o => o.OrderId == id &&
                o.Usuario == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}