using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ventas.Models;

namespace Ventas.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly VentaDB db = new VentaDB();
        // GET: api/Producto
        public IEnumerable<tbl_producto> GetProducto()
        {
            List<tbl_producto> producto = db.tbl_producto.Where(p => p.estado == true).ToList();
            return producto;
        }

        // GET: api/Producto/5
        public IEnumerable<tbl_producto> GetProducto(int id)
        {
            var productos = db.tbl_producto.Where(p => p.productoID == id);
            List<tbl_producto> producto = productos.ToList();
            return producto;
        }

        // POST: api/Producto
        public async Task<IHttpActionResult> PostProducto([FromBody]ProductoDTOInsertar producto)
        {
            try { 
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    tbl_producto p = new tbl_producto
                    {
                        estado = producto.estado,
                        nombre = producto.nombre,
                        marca = producto.marca,
                        modelo = producto.modelo,
                        codigobarra = producto.codigobarra,
                        cantidad = producto.cantidad,
                        presentacion = producto.presentacion,
                        precio = producto.precio,
                        fecharegistro = producto.fecharegistro,
                        fechamodificacion = producto.fechamodificacion
                    };
                    db.tbl_producto.Add(p);
                    await db.SaveChangesAsync();
                    return Ok(producto);
                }catch(Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Producto/5
        public async Task<IHttpActionResult> PutProducto([FromBody]ProductoDTOActualizar producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_producto p = db.tbl_producto.Find(producto.productoID);

                p.estado = producto.estado;
                p.nombre = producto.nombre;
                p.marca = producto.marca;
                p.modelo = producto.modelo;
                p.codigobarra = producto.codigobarra;
                p.cantidad = producto.cantidad;
                p.presentacion = producto.presentacion;
                p.precio = producto.precio;
                p.fecharegistro = producto.fecharegistro;
                p.fechamodificacion = producto.fechamodificacion;
                await db.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Producto/5
        //public void Delete([FromBody] tbl_producto producto)
        //{
        //    db.tbl_producto.Add(producto);
        //    db.SaveChanges();
        //}
    }
}
