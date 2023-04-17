using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Ventas.Models;

namespace ReporteVentas.Controllers
{
    public class ReporteVentaController : Controller
    {
        // GET: ReporteVenta
        public async Task<ActionResult> Index(string inicio, string fin, string codigoventa)
        {
            string url = "";
           DateTime fechaInicio = DateTime.Now, fechaFin = DateTime.Now; string codigoVenta= "", ano ="",mes ="",dia="";
            if (codigoventa == string.Empty || codigoventa == null)
            {
                url = "http://localhost:58144/api/Reportes/";
            }
            else
            {
                fechaInicio = Convert.ToDateTime(inicio);
                fechaFin = Convert.ToDateTime(fin);
                ano = fechaInicio.Year.ToString();
                mes = fechaInicio.Month.ToString();
                dia = fechaInicio.Day.ToString();
                inicio = Convert.ToString(ano + "-" + mes + "-" + dia);
                ano = fechaFin.Year.ToString();
                mes = fechaFin.Month.ToString();
                dia = fechaFin.Day.ToString();
                fin = Convert.ToString(ano + "-" + mes + "-" + dia);
                codigoVenta = codigoventa;
                url = "http://localhost:58144/api/Reportes/" + inicio + "/" + fin + "/?codigoventa=" + codigoVenta;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                string result = "";
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    result = reader.ReadToEnd();
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                var data = await Task.Run(() => JsonConvert.DeserializeObject<List<VentasDTOReportes>>(result));
                return View(data.ToList());
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: ReporteVenta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReporteVenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteVenta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: ReporteVenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReporteVenta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReporteVenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReporteVenta/Delete/5
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
