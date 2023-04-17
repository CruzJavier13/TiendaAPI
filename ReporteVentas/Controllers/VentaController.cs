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
    public class VentaController : Controller
    {
        // GET: Venta
        public async Task<ActionResult> Index()
        {
            string url = "http://localhost:58144/api/Venta";
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
            var data = await Task.Run(() => JsonConvert.DeserializeObject<List<tbl_venta>>(result));
            return View(data.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateVenta()
        {
            return View();
        }

        // GET: Venta/Create
        //public List<tbl_venta> Create(List<tbl_venta> venta)
        //{
        //    return venta.ToList();
        //}

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(tbl_venta venta)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(List<tbl_venta> venta)
        {

            return View(venta);
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, List<tbl_venta> venta)
        {
            string result = "";
            try
            {
                string url = "http://localhost:58144/api/Cliente";
                JavaScriptSerializer js = new JavaScriptSerializer();
                var client = new HttpClient();
                List<tbl_venta> ventas = new List<tbl_venta>(); 
                tbl_venta json = new tbl_venta();
                foreach (var item in venta)
                {
                    json.ventaID = item.ventaID;
                    json.codigoventa = item.codigoventa;
                    json.estado = true;
                    json.empleado = item.empleado;
                    json.cliente = item.cliente;
                    json.producto = item.producto;
                    //json.fecha = item.fecha;
                    json.formapago = item.formapago;
                    json.descuento = item.descuento;
                    json.preciounidad = item.preciounidad;
                    json.preciounidad = item.preciounidad;
                    json.cantidad = item.cantidad;
                    json.impuesto = item.impuesto;
                    json.total = item.total;
                    ventas.Add(json);
                }

                var data = Newtonsoft.Json.JsonConvert.SerializeObject(ventas);
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

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
