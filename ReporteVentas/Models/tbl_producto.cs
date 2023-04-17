namespace Ventas.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_producto()
        {
            tbl_venta = new HashSet<tbl_venta>();
        }

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

        public virtual ICollection<tbl_venta> tbl_venta { get; set; }
    }
}
