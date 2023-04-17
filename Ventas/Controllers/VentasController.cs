using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Ventas.Models;

namespace Ventas.Controllers
{
    public class VentaController : ApiController
    {
        private readonly VentaDB db = new VentaDB();
        // GET: api/Ventas
        public IEnumerable<tbl_venta> GetVenta()
        {
            List<tbl_venta> ventas = db.tbl_venta.Where(v => v.estado == true).ToList();
            return ventas;
        }

        // GET: api/Ventas/5
        public IEnumerable<tbl_venta> GetVenta(string id)
        {
            var ventas = db.tbl_venta.Where(v => v.codigoventa == id);
            List<tbl_venta> venta = ventas.ToList();
            return venta;
        }

        // POST: api/Ventas
        public async Task<IHttpActionResult> PostVenta([FromBody]List<VentaDTOInsertar> venta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_venta ventaDB;
                List<tbl_venta> v = new List<tbl_venta>();
                foreach(var item in venta)
                {
                    ventaDB = new tbl_venta();
                    ventaDB.codigoventa = item.codigoventa;
                    ventaDB.estado = item.estado;
                    ventaDB.empleado = item.empleado;
                    ventaDB.cliente = item.cliente;
                    ventaDB.producto = item.producto;
                    ventaDB.fecha = item.fecha;
                    ventaDB.formapago = item.formapago;
                    ventaDB.descuento = item.descuento;
                    //ventaDB.preciounidad = item.preciounidad;
                    ventaDB.cantidad = item.cantidad;
                    //ventaDB.impuesto = item.impuesto;
                    //ventaDB.total = item.total;
                    v.Add(ventaDB);
                }
                db.tbl_venta.AddRange(v);
                await db.SaveChangesAsync();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Ventas/5
        public async Task<IHttpActionResult> PutVenta(string id, [FromBody]List<VentaDTOActualizar> venta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(id == null || id == "")
                {
                    return InternalServerError();
                }
                List<tbl_venta> ventas = new List<tbl_venta>(); 
                tbl_venta p = db.tbl_venta.Find(id);
                foreach (var item in venta)
                {
                    p = new tbl_venta();
                    p.codigoventa = item.codigoventa;
                    p.estado = item.estado;
                    p.empleado = item.empleado;
                    p.cliente = item.cliente;
                    p.producto = item.producto;
                    p.fecha = item.fecha;
                    p.formapago = item.formapago;
                    p.descuento = item.descuento;
                    //ventaDB.preciounidad = item.preciounidad;
                    p.cantidad = item.cantidad;
                    //ventaDB.impuesto = item.impuesto;
                    //ventaDB.total = item.total;
                    ventas.Add(p);
                }
                //p.codigoventa = venta.codigoventa;
                //p.estado = venta.estado;
                //p.empleado = venta.empleado;
                //p.cliente = venta.cliente;
                //p.producto = venta.producto;
                //p.fecha = venta.fecha;
                //p.formapago = venta.formapago;
                //p.descuento = venta.descuento;
                //p.preciounidad = venta.preciounidad;
                //p.cantidad = venta.cantidad;
                //p.impuesto = venta.impuesto;
                //p.total = venta.total;
                db.tbl_venta.AddRange(ventas);
                await db.SaveChangesAsync();
                return Ok(venta);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
