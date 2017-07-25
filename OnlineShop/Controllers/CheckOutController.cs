using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Shop;

namespace OnlineShop.Controllers
{
    public class CheckOutController : Controller
    {
        Shopstore DB = new Shopstore();
        const string PromoCode = "50";

        public ActionResult AddressAndPayment()
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


                    DB.Orden.Add(order);
                    DB.SaveChanges();

                    var cart = CarritoCompras.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

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

            bool isValid = DB.Orden.Any(
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