using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Orden
    {
        [Key]
        public int OrderId { get; set; }
        public string Usuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime DiaOrden { get; set; }
        public List<DetalleOrden> DetalleOrden{ get; set; }
    }
}