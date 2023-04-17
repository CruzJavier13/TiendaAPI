using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class VentaDTOInsertar
    {
        [StringLength(20)]
        public string codigoventa { get; set; }
        public bool estado { get; set; }

        public int? empleado { get; set; }

        public int? cliente { get; set; }

        public int? producto { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [StringLength(20)]
        public string formapago { get; set; }

        public double descuento { get; set; }

        public decimal preciounidad { get; set; }

        public int cantidad { get; set; }

        public double impuesto { get; set; }

        public decimal? total { get; set; }

        public virtual tbl_cliente tbl_cliente { get; set; }
        public virtual tbl_empleado tbl_empleado { get; set; }
        public virtual tbl_producto tbl_producto { get; set; }
    }
}