using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Shop;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        Shopstore db = new Shopstore();
        private List<Items> GetTopSellingItems(int count)
        {
            return db.Items.OrderByDescending(i => i.OrdenDetalle.Count())
                .Take(count)
                .ToList();
        }
        public ActionResult Index()
        {
            var items = GetTopSellingItems(4);
            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}