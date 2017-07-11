using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    [Bind(Exclude = "ItemId")]
    public class Items
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ItemId { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        [DisplayName("Proveedor")]
        public int ProductorId { get; set; }
        [Required(ErrorMessage ="Se necesita un titulo de item")]
        [StringLength(120)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Se necesita un precio")]
        [Range(10,1000000000,ErrorMessage ="el precio tiene que estar entre 10 y 1,000,000,000")]
        public decimal Precio { get; set; }
        [DisplayName("Item Art Url")]
        public string ItemArtUrl { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Productor Procductor { get; set; }
    }
}