using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineShop.Models;

namespace OnlineShop.Shop
{
    public class Shopstore : DbContext
    {
        public Shopstore() : base ("DefaultConnection")
            {
            }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Productor> Productor { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }

        public System.Data.Entity.DbSet<OnlineShop.ViewModels.CarritoComprasModel> CarritoComprasModels { get; set; }
    }
}