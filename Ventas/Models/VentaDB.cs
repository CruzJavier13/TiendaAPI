using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ventas.Models
{
    public partial class VentaDB : DbContext
    {
        public VentaDB()
            : base("name=VentaDB")
        {
        }

        public virtual DbSet<tbl_cliente> tbl_cliente { get; set; }
        public virtual DbSet<tbl_empleado> tbl_empleado { get; set; }
        public virtual DbSet<tbl_producto> tbl_producto { get; set; }
        public virtual DbSet<tbl_venta> tbl_venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .HasMany(e => e.tbl_venta)
                .WithOptional(e => e.tbl_cliente)
                .HasForeignKey(e => e.cliente);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.cargo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.inss)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.categoria)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_empleado>()
                .HasMany(e => e.tbl_venta)
                .WithOptional(e => e.tbl_empleado)
                .HasForeignKey(e => e.empleado);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.marca)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.modelo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.codigobarra)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.presentacion)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_producto>()
                .Property(e => e.precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_producto>()
                .HasMany(e => e.tbl_venta)
                .WithOptional(e => e.tbl_producto)
                .HasForeignKey(e => e.producto);

            modelBuilder.Entity<tbl_venta>()
                .Property(e => e.codigoventa)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_venta>()
                .Property(e => e.formapago)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_venta>()
                .Property(e => e.preciounidad)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_venta>()
                .Property(e => e.total)
                .HasPrecision(10, 2);
        }
    }
}
