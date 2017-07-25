using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Orden
    {
        [ScaffoldColumn(false)]
        [Key]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Primer nombre es requerido")]
        [DisplayName("Primer Nombre")]
        [StringLength(160)]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = "Segundo nombre es requerido")]
        [DisplayName("Segundo Nombre")]
        [StringLength(160)]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage ="Direccion requerida")]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="Ciudad requerida")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage ="Estado es requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage ="Pais es requerido")]
        public string Pais { get; set; }
        [Required(ErrorMessage ="Telefono es requerido")]
        [StringLength(10)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
           ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime DiaOrden { get; set; }
        public List<DetalleOrden> DetalleOrden{ get; set; }
    }
}