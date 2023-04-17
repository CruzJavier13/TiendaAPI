using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class EmpleadoDTOActualizar
    {

        [Key]
        public int empleadoID { get; set; }
        public bool estado { get; set; }

        [Required]
        [StringLength(12)]
        public string cargo { get; set; }

        [Required]
        [StringLength(120)]
        public string nombres { get; set; }

        [Required]
        [StringLength(120)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string cedula { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(10)]
        public string inss { get; set; }

        public bool licensia { get; set; }

        [StringLength(1)]
        public string categoria { get; set; }

        public string direccion { get; set; }

        [Required]
        [StringLength(16)]
        public string telefono { get; set; }

        [StringLength(250)]
        public string correo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecharegistro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechamodificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tbl_venta> tbl_venta { get; set; }
    }
}