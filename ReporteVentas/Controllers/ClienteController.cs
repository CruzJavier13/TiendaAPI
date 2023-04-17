using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Ventas.Models;

namespace ReporteVentas.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            string url = "http://localhost:58144/api/Cliente";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                result =  reader.ReadToEnd();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = await Task.Run(() => JsonConvert.DeserializeObject<List<tbl_cliente>>(result));
            return View(data.ToList());
        }
        //public async Task<ActionResult> Listar(tbl_cliente cliente)
        //{
        //    string url = "http://localhost:58144/api/Cliente";
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "GET";
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    string result = "";
        //    using (Stream stream = response.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //        result = reader.ReadToEnd();
        //    }
        //    return View();
        //}

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }
            [HttpPost]
        public async Task<ActionResult> Create(tbl_cliente cliente)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Cliente";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_cliente json = new tbl_cliente();
                json.estado = true;
                json.nombres = cliente.nombres;
                json.apellidos = cliente.apellidos;
                json.cedula = cliente.cedula;
                json.sexo = cliente.sexo;
                json.direccion = cliente.direccion;
                json.telefono = cliente.telefono;
                json.correo = cliente.correo;
                json.fecharegistro = cliente.fecharegistro;
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
            catch(Exception e)
            {
                result = e.Message;
            }
            return View(result);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int clienteID, bool estado, string nombres, string apellidos, string cedula, string sexo, string direccion, string telefono, string correo, DateTime fecharegistro, DateTime fechamodificacion)
        {
            // Inicializar un objeto ClienteModel con los valores de los parámetros de la URL
            var model = new tbl_cliente
            {
                clienteID = clienteID,
                estado = estado,
                nombres = nombres,
                apellidos = apellidos,
                cedula = cedula,
                sexo = sexo,
                direccion = direccion,
                telefono = telefono,
                correo = correo,
                fecharegistro = fecharegistro,
                fechamodificacion = fechamodificacion
            };

            // Pasar el modelo a la vista
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(tbl_cliente cliente)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Cliente";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_cliente json = new tbl_cliente();
                json.clienteID = cliente.clienteID;
                json.estado = cliente.estado;
                json.nombres = cliente.nombres;
                json.apellidos = cliente.apellidos;
                json.cedula = cliente.cedula;
                json.sexo = cliente.sexo;
                json.direccion = cliente.direccion;
                json.telefono = cliente.telefono;
                json.correo = cliente.correo;
                json.fecharegistro = cliente.fecharegistro;
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

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(tbl_cliente cliente)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Cliente";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_cliente json = new tbl_cliente();
                json.clienteID = cliente.clienteID;
                json.estado = false;
                json.nombres = cliente.nombres;
                json.apellidos = cliente.apellidos;
                json.cedula = cliente.cedula;
                json.sexo = cliente.sexo;
                json.direccion = cliente.direccion;
                json.telefono = cliente.telefono;
                json.correo = cliente.correo;
                json.fecharegistro = cliente.fecharegistro;
                json.fechamodificacion = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year+ "-" +DateTime.Now.Month+ "-" +DateTime.Now.Day));

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
