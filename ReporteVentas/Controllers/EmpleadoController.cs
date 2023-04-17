using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Ventas.Models;

namespace ReporteVentas.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public async Task<ActionResult> Index()
        {
            string url = "http://localhost:58144/api/Empleado";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                result = reader.ReadToEnd();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = await Task.Run(() => JsonConvert.DeserializeObject<List<tbl_empleado>>(result));
            return View(data.ToList());
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        public async Task<ActionResult> Create(tbl_empleado empleado)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Empleado";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_empleado json = new tbl_empleado();
                json.empleadoID = empleado.empleadoID;
                json.estado = true;
                json.cargo = empleado.cargo;
                json.nombres = empleado.nombres;
                json.apellidos = empleado.apellidos;
                json.cedula = empleado.cedula;
                json.sexo = empleado.sexo;
                json.inss = empleado.inss;
                json.licensia = empleado.licensia;
                json.categoria = empleado.categoria;
                json.direccion = empleado.direccion;
                json.telefono = empleado.telefono;
                json.correo = empleado.correo;
                json.fecharegistro = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day));
                //json.fechamodificacion = cliente.fechamodificacion;
                //SerializeObject
                var data = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.PreAuthenticate = true;
                //request.Timeout = 10000;
                request.ContentType = "application/json;charset=utf-8'";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return View(result);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int empleadoID, bool estado, string cargo, string nombres, string apellidos, string cedula, string sexo, string inss, bool licensia, string categoria, string direccion, string telefono, string correo, DateTime fecharegistro, DateTime? fechamodificacion = null)
        {
            var model = new tbl_empleado
            {
                empleadoID = empleadoID,
                estado = estado,
                cargo = cargo,
                nombres = nombres,
                apellidos = apellidos,
                cedula = cedula,
                sexo = sexo,
                inss = inss,
                licensia = licensia,
                categoria = categoria,
                direccion = direccion,
                telefono = telefono,
                correo = correo,
                fecharegistro = fecharegistro,
                fechamodificacion = fechamodificacion,
            };

            return View(model);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(tbl_empleado empleado)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Empleado";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_empleado json = new tbl_empleado();
                json.empleadoID = empleado.empleadoID;
                json.estado = empleado.estado;
                json.cargo = empleado.cargo;
                json.nombres = empleado.nombres;
                json.apellidos = empleado.apellidos;
                json.cedula = empleado.cedula;
                json.sexo = empleado.sexo;
                json.inss = empleado.inss;
                json.licensia = empleado.licensia;
                json.categoria = empleado.categoria;
                json.direccion = empleado.direccion;
                json.telefono = empleado.telefono;
                json.correo = empleado.correo;
                //json.fecharegistro = empleado.fecharegistro;
                json.fechamodificacion = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day));

                var data = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.PreAuthenticate = true;
                //request.Timeout = 10000;
                request.ContentType = "application/json;charset=utf-8'";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return View(result);
        }

        // GET: Empleado/Delete/5
        public async Task<ActionResult> Delete(tbl_empleado empleado)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Empleado";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_empleado json = new tbl_empleado();
                json.empleadoID = empleado.empleadoID;
                json.estado = false;
                json.cargo = empleado.cargo;
                json.nombres = empleado.nombres;
                json.apellidos = empleado.apellidos;
                json.cedula = empleado.cedula;
                json.sexo = empleado.sexo;
                json.inss = empleado.inss;
                json.licensia = empleado.licensia;
                json.categoria = empleado.categoria;
                json.direccion = empleado.direccion;
                json.telefono = empleado.telefono;
                json.correo = empleado.correo;
                //json.fecharegistro = empleado.fecharegistro;
                json.fechamodificacion = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day));

                var data = Newtonsoft.Json.JsonConvert.SerializeObject(json);
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.PreAuthenticate = true;
                //request.Timeout = 10000;
                request.ContentType = "application/json;charset=utf-8'";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return View(result);
        }
    }
}
