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
    public class EmpleadoController : ApiController
    {
        private readonly VentaDB db = new VentaDB();
        // GET: api/Empleado
        public IEnumerable<tbl_empleado> GetEmpleado()
        {
            List<tbl_empleado> empleados = db.tbl_empleado.Where(e=>e.estado == true).ToList();
            return empleados;
        }

        // GET: api/Empleado/5
        public IEnumerable<tbl_empleado> GetEmpleado(int id)
        {
            var empleados = db.tbl_empleado.Where(c => c.empleadoID == id);
            List<tbl_empleado> empleado = empleados.ToList();
            return empleado;
        }

        // POST: api/Empleado
        public async Task<IHttpActionResult> PostEmpleado([FromBody]EmpleadoDTOInsertar empleado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_empleado emp = new tbl_empleado
                {
                    estado = empleado.estado,
                    cargo = empleado.cargo,
                    nombres = empleado.nombres,
                    apellidos = empleado.apellidos,
                    cedula = empleado.cedula,
                    sexo = empleado.sexo,
                    inss = empleado.inss,
                    licensia = empleado.licensia,
                    categoria = empleado.categoria,
                    direccion = empleado.direccion,
                    telefono = empleado.telefono,
                    correo = empleado.correo,
                    fecharegistro = empleado.fecharegistro,
                    fechamodificacion = empleado.fechamodificacion
                };
                db.tbl_empleado.Add(emp);
                await db.SaveChangesAsync();

                return Ok(empleado);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Empleado/5
        public async Task<IHttpActionResult> PutEmpleado([FromBody] EmpleadoDTOActualizar empleado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                tbl_empleado e = db.tbl_empleado.Find(empleado.empleadoID);

                e.estado = empleado.estado;
                e.cargo = empleado.cargo;
                e.nombres = empleado.nombres;
                e.apellidos = empleado.apellidos;
                e.cedula = empleado.cedula;
                e.sexo = empleado.sexo;
                e.inss = empleado.inss;
                e.licensia = empleado.licensia;
                e.categoria = empleado.categoria;
                e.direccion = empleado.direccion;
                e.telefono = empleado.telefono;
                e.correo = empleado.correo;
                e.fecharegistro = empleado.fecharegistro;
                e.fechamodificacion = empleado.fechamodificacion;

                await db.SaveChangesAsync();
                return Ok(empleado);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Empleado/5
        //public void DeleteEmpleado([FromBody] tbl_empleado empleado)
        //{
        //    db.tbl_empleado.Add(empleado);
        //    db.SaveChanges();
        //}
    }
}
