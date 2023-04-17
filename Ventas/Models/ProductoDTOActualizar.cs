﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class ProductoDTOActualizar
    {
        [Key]
        public int productoID { get; set; }

        public bool estado { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string marca { get; set; }

        [Required]
        [StringLength(40)]
        public string modelo { get; set; }

        [StringLength(120)]
        public string codigobarra { get; set; }

        public int? cantidad { get; set; }

        [StringLength(20)]
        public string presentacion { get; set; }

        public decimal? precio { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecharegistro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechamodificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tbl_venta> tbl_venta { get; set; }
    }
}