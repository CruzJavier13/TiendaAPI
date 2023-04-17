using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Ventas.Models;

namespace Ventas.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly VentaDB db = new VentaDB();
        // GET: api/Cliente
        public IEnumerable<tbl_cliente> GetCliente()
        {
            List<tbl_cliente> cliente = db.tbl_cliente.OrderBy(c => c.clienteID).Where(c => c.estado == true).ToList();
            return cliente;
        }

        // GET: api/Cliente/5
        public IEnumerable<tbl_cliente> GetCliente(int id)
        {
            var clientes = db.tbl_cliente.Where(c => c.clienteID == id);
            List<tbl_cliente> cliente = clientes.ToList();
            //string json = JsonSerializer.Serialize({ "": "" });
            return cliente;
        }

        // POST: api/Cliente
        public async Task<IHttpActionResult> PostCliente([FromBody] ClienteDTOInsertar cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_cliente cli = new tbl_cliente
                {
                    estado = cliente.estado,
                    nombres = cliente.nombres,
                    apellidos = cliente.apellidos,
                    cedula = cliente.cedula,
                    sexo = cliente.sexo,
                    direccion = cliente.direccion,
                    telefono = cliente.telefono,
                    correo = cliente.correo,
                    fecharegistro = cliente.fecharegistro,
                    fechamodificacion = cliente.fechamodificacion
                };
                db.tbl_cliente.Add(cli);
                await db.SaveChangesAsync();

                return Ok(cliente);
            } catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        // PUT: api/Cliente/5
        [HttpPut]
        public async Task<IHttpActionResult> PutCliente([FromBody] ClienteDTOActualizar cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_cliente c = db.tbl_cliente.Find(cliente.clienteID);

                c.estado = cliente.estado;
                c.nombres = cliente.nombres;
                c.apellidos = cliente.apellidos;
                c.cedula = cliente.cedula;
                c.sexo = cliente.sexo;
                c.direccion = cliente.direccion;
                c.telefono = cliente.telefono;
                c.correo = cliente.correo;
                c.fecharegistro = cliente.fecharegistro;
                c.fechamodificacion = cliente.fechamodificacion;
                //db.tbl_cliente.Add(cli);
                //await db.SaveChangesAsync();

                //db.tbl_cliente.Add(cli);
                await db.SaveChangesAsync();
                return Ok("Guardado");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Cliente/5
        //[HttpPut]
        //public async Task<IHttpActionResult> DeleteCliente([FromBody] ClienteDTOActualizar cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    tbl_cliente cli = new tbl_cliente
        //    {
        //        clienteID = cliente.clienteID,
        //        estado = false,
        //    };
        //    //db.tbl_cliente.Add(cli);
        //    //await db.SaveChangesAsync();

        //    db.tbl_cliente.Add(cli);
        //    await db.SaveChangesAsync();
        //    return Ok(cliente);
        //}
    }
}
