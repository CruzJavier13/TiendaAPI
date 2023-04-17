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
    public class ProductoController : Controller
    {
        // GET: Producto
        public async Task<ActionResult> Index()
        {
            string url = "http://localhost:58144/api/Producto";
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
            var data = await Task.Run(() => JsonConvert.DeserializeObject<List<tbl_producto>>(result));
            return View(data.ToList());
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public async Task<ActionResult> Create(tbl_producto producto)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Producto";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_producto json = new tbl_producto();
                json.productoID = producto.productoID;
                json.estado = true;
                json.nombre = producto.nombre;
                json.marca = producto.marca;
                json.modelo = producto.modelo;
                json.codigobarra = producto.codigobarra;
                json.cantidad = producto.cantidad;
                json.presentacion = producto.presentacion;
                json.precio = producto.precio;
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int productoID, bool estado, string nombre, string marca, string modelo, string codigobarra, int cantidad, string presentacion, decimal precio, DateTime fecharegistro, DateTime fechamodificacion, ICollection<tbl_venta> tbl_venta)
        {
            var model = new tbl_producto
            {
                productoID = productoID,
                estado = true,
                nombre = nombre,
                marca = marca,
                modelo = modelo,
                codigobarra = codigobarra,
                cantidad = cantidad,
                presentacion = presentacion,
                precio = precio,
                fecharegistro = fecharegistro,
                fechamodificacion = fechamodificacion,
            };

            return View(model);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(tbl_producto producto)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Producto";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_producto json = new tbl_producto();
                json.productoID = producto.productoID;
                json.estado = true;
                json.nombre = producto.nombre;
                json.marca = producto.marca;
                json.modelo = producto.modelo;
                json.codigobarra = producto.codigobarra;
                json.cantidad = producto.cantidad;
                json.presentacion = producto.presentacion;
                json.precio = producto.precio;
                //json.fecharegistro = producto.fecharegistro;
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


        // POST: Producto/Delete/5
        public async Task<ActionResult> Delete(tbl_producto producto)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Producto";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                tbl_producto json = new tbl_producto();
                json.productoID = producto.productoID;
                json.estado = false;
                json.nombre = producto.nombre;
                json.marca = producto.marca;
                json.modelo = producto.modelo;
                json.codigobarra = producto.codigobarra;
                json.cantidad = producto.cantidad;
                json.presentacion = producto.presentacion;
                json.precio = producto.precio;
                //json.fecharegistro = producto.fecharegistro;
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
