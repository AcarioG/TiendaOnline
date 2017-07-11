using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int ItemId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public virtual Items Item { get; set; }
        public virtual Orden Orden { get; set; }
    }
}