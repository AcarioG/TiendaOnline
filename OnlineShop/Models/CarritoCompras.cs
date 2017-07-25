using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Shop;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    
    public class CarritoCompras
    {
        Shopstore storeDB = new Shopstore();
        string CarritoCompraId { get; set; }
        public const string CartSessionKey = "CarritoId";
        public static CarritoCompras GetCart(HttpContextBase context)
        {
            var carrito = new CarritoCompras();
            carrito.CarritoCompraId = carrito.GetCartId(context);
            return carrito;
        }
        // Helper method to simplify shopping cart calls
        public static CarritoCompras GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Items item)
        {

            var ItemCarrito = storeDB.Carrito.SingleOrDefault(
                c => c.CarritoId == CarritoCompraId
                && c.ItemId == item.ItemId);

            if (ItemCarrito == null)
            {
                
                ItemCarrito = new Carrito
                {
                    ItemId = item.ItemId,
                    CarritoId = CarritoCompraId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carrito.Add(ItemCarrito);
            }
            else
            {

                ItemCarrito.Count++;
            }
            
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            
            var ItemCarrito = storeDB.Carrito.Single(
                cart => cart.CarritoId == CarritoCompraId
                && cart.RegistroId == id);

            int itemCount = 0;

            if (ItemCarrito != null)
            {
                if (ItemCarrito.Count > 1)
                {
                    ItemCarrito.Count--;
                    itemCount = ItemCarrito.Count;
                }
                else
                {
                    storeDB.Carrito.Remove(ItemCarrito);
                }
                
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void VaciarCarrito()
        {
            var ItemCarritos = storeDB.Carrito.Where(
                cart => cart.CarritoId == CarritoCompraId);

            foreach (var ItemCarrito in ItemCarritos)
            {
                storeDB.Carrito.Remove(ItemCarrito);
            }
            
            storeDB.SaveChanges();
        }
        public List<Carrito> GetCartItems()
        {
            return storeDB.Carrito.Where(
                cart => cart.CarritoId == CarritoCompraId).ToList();
        }
        public int GetCount()
        {

            int? count = (from ItemCarrito in storeDB.Carrito
                          where ItemCarrito.CarritoId == CarritoCompraId
                          select (int?) ItemCarrito.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            
            decimal? total = (from ItemCarrito in storeDB.Carrito
                              where ItemCarrito.CarritoId == CarritoCompraId
                              select (ItemCarrito.Count *
                              ItemCarrito.Item.Precio)).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Orden orden)
        {
            decimal orderTotal = 0;

            var ItemCarrito = GetCartItems();
            
            foreach (var item in ItemCarrito)
            {
                var orderDetail = new DetalleOrden
                {
                    ItemId = item.ItemId,
                    OrdenId = orden.OrderId,
                    PrecioUnidad = item.Item.Precio,
                    Cantidad = item.Count
                };
                
                orderTotal += (item.Count * item.Item.Precio);

                storeDB.DetalleOrden.Add(orderDetail);
            }

            orden.Total = orderTotal;

            storeDB.SaveChanges();
            
            VaciarCarrito();
            
            return orden.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    
                    Guid tempCartId = Guid.NewGuid();
                    
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        public void MigrateCart(string userName)
        {
            var Carritocompras = storeDB.Carrito.Where(
                c => c.CarritoId == CarritoCompraId);

            foreach (Carrito item in Carritocompras)
            {
                item.CarritoId = userName;
            }
            storeDB.SaveChanges();
        }


    }
    }
