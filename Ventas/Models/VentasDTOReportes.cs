using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public partial class VentasDTOReportes
    {
        public int ventaID { get; set; }

        public string codigoventa { get; set; }
        public bool estado { get; set; }
        public DateTime fecha { get; set; }
        public string formapago { get; set; }
        public string clienteNombres { get; set; }
        public string clienteApellidos { get; set; }
        public string empleadoNombres { get; set; }
        public string empleadoApellidos { get; set; }
        public double descuento { get; set; }
        public string nombreProducto { get; set; }
        public string marcaProducto { get; set; }
        public int cantidad { get; set; }
        public double impuesto { get; set; }
        public decimal preciounidad { get; set; }
        public decimal? total { get; set; }
    }
}