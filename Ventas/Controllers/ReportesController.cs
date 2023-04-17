using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ventas.Models;

namespace Ventas.Controllers
{
    public class ReportesController : ApiController
    {
        private readonly VentaDB db = new VentaDB();

        [Route("api/Reportes/{campo1}/{campo2}")]
        [HttpGet]
        public IEnumerable<VentasDTOReportes> GetVenta(DateTime campo1, DateTime campo2, string codigoventa)
        {
            VentasDTOReportes ventas;
            List<VentasDTOReportes> listaVentas = new List<VentasDTOReportes>(); ;
            //var query =  db.tbl_venta.Join(db.tbl_cliente, v => v.cliente, c => c.clienteID ,(v,c) => new 
            //{  v.ventaID ,v.estado,v.fecha, v.formapago, c.nombres, c.apellidos , v.descuento, v.producto, v.cantidad, v.impuesto, v.preciounidad, v.total
            //}).Where(n => n.nombres == campo || n.apellidos == campo).ToList();
            //List<object> venta = query.ToList();
            var resultadoJoin = from t1 in db.tbl_venta
                                join t2 in db.tbl_cliente on t1.cliente equals t2.clienteID
                                join t3 in db.tbl_empleado on t1.empleado equals t3.empleadoID
                                join t4 in db.tbl_producto on t1.producto equals t4.productoID
                                where t1.fecha >= campo1 && t1.fecha <= campo2 && t1.codigoventa == codigoventa  
                                select new
                                {
                                    t1.ventaID,
                                    t1.codigoventa,
                                    t1.estado,
                                    t1.fecha,
                                    t1.formapago,
                                    t2.nombres,
                                    t2.apellidos,
                                    Nombre = t3.nombres,
                                    Apellido = t3.apellidos,
                                    t1.descuento,
                                    t4.nombre,
                                    t4.marca,
                                    t1.cantidad,
                                    t1.impuesto,
                                    t1.preciounidad,
                                    t1.total
                                };
            foreach (var venta in resultadoJoin)
            {
                ventas = new VentasDTOReportes
                {
                    ventaID = venta.ventaID,
                    codigoventa = venta.codigoventa,
                    estado = venta.estado,
                    fecha = venta.fecha,
                    formapago = venta.formapago,
                    clienteNombres = venta.nombres,
                    clienteApellidos = venta.apellidos,
                    empleadoNombres = venta.Nombre,
                    empleadoApellidos = venta.Apellido,
                    descuento = venta.descuento,
                    nombreProducto = venta.nombre,
                    marcaProducto = venta.marca,
                    cantidad = venta.cantidad,
                    impuesto = venta.impuesto,
                    preciounidad = venta.preciounidad,
                    total = venta.total
                };
                // aquí puedes utilizar las propiedades del objeto anónimo
                Console.WriteLine($"Venta: {venta.ventaID}, Cliente: {venta.nombre} {venta.apellidos}, Empleado: {venta.Nombre} {venta.Apellido}, Producto: {venta.nombre}, Cantidad: {venta.cantidad}, Total: {venta.total}");
                listaVentas.Add(ventas);
            }
            List<VentasDTOReportes> ventaReporte = listaVentas;

            return ventaReporte.ToList().OrderBy(v => v.codigoventa);
        }
        [HttpGet]
        public IEnumerable<VentasDTOReportes> GetVenta()
        {
            VentasDTOReportes ventas;
            List<VentasDTOReportes> listaVentas = new List<VentasDTOReportes>(); ;
            //var query =  db.tbl_venta.Join(db.tbl_cliente, v => v.cliente, c => c.clienteID ,(v,c) => new 
            //{  v.ventaID ,v.estado,v.fecha, v.formapago, c.nombres, c.apellidos , v.descuento, v.producto, v.cantidad, v.impuesto, v.preciounidad, v.total
            //}).Where(n => n.nombres == campo || n.apellidos == campo).ToList();
            //List<object> venta = query.ToList();
            var resultadoJoin = from t1 in db.tbl_venta
                                join t2 in db.tbl_cliente on t1.cliente equals t2.clienteID
                                join t3 in db.tbl_empleado on t1.empleado equals t3.empleadoID
                                join t4 in db.tbl_producto on t1.producto equals t4.productoID
                                where t1.estado == true
                                select new
                                {
                                    t1.ventaID,
                                    t1.codigoventa,
                                    t1.estado,
                                    t1.fecha,
                                    t1.formapago,
                                    t2.nombres,
                                    t2.apellidos,
                                    Nombre = t3.nombres,
                                    Apellido = t3.apellidos,
                                    t1.descuento,
                                    t4.nombre,
                                    t4.marca,
                                    t1.cantidad,
                                    t1.impuesto,
                                    t1.preciounidad,
                                    t1.total
                                };
            foreach (var venta in resultadoJoin)
            {
                ventas = new VentasDTOReportes
                {
                    ventaID = venta.ventaID,
                    codigoventa = venta.codigoventa,
                    estado = venta.estado,
                    fecha = venta.fecha,
                    formapago = venta.formapago,
                    clienteNombres = venta.nombres,
                    clienteApellidos = venta.apellidos,
                    empleadoNombres = venta.Nombre,
                    empleadoApellidos = venta.Apellido,
                    descuento = venta.descuento,
                    nombreProducto = venta.nombre,
                    marcaProducto = venta.marca,
                    cantidad = venta.cantidad,
                    impuesto = venta.impuesto,
                    preciounidad = venta.preciounidad,
                    total = venta.total
                };
                // aquí puedes utilizar las propiedades del objeto anónimo
                Console.WriteLine($"Venta: {venta.ventaID}, Cliente: {venta.nombre} {venta.apellidos}, Empleado: {venta.Nombre} {venta.Apellido}, Producto: {venta.nombre}, Cantidad: {venta.cantidad}, Total: {venta.total}");
                listaVentas.Add(ventas);
            }
            List<VentasDTOReportes> ventaReporte = listaVentas;

            return ventaReporte.ToList().OrderBy(v => v.codigoventa);
        }
    }
}
