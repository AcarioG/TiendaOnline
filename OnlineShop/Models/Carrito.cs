using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Carrito
    {
        [Key]
        public int RegistroId { get; set; }
        public string CarritoId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Items Item { get; set; }
    }
}