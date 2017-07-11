using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class EliminarCarritoCompraModel
    {
        public string Mensaje { get; set; }
        public decimal CarritoTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}