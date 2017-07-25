using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.ViewModels
{
    
    public class CarritoComprasModel
    {
        public int ID { get; set; }
        public List<Carrito> ItemCarrito { get; set; }
        public decimal CarritoTotal { get; set; }
    }
}