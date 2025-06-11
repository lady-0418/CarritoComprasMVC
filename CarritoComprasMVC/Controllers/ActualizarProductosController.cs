using CarritoComprasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarritoComprasMVC.Controllers
{
    public class ActualizarProductosController : Controller
    {
        public async Task<ActionResult> ActualizarProductos()
        {
            List<Productos> productos = new List<Productos>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Productos");
                    if (response.IsSuccessStatusCode)
                    {
                        productos = await response.Content.ReadAsAsync<List<Productos>>();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            ViewBag.listaProductos = productos;
            return View("ListaProductos");
        }

        [HttpPost]
        public async Task<ActionResult> ActualizarProductos(Productos Producto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(Producto);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Productos/{Producto.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = "Producto actualizado correctamente";
                    }
                    else
                    {
                        TempData["Mensaje"] = $"Error al actualizar: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = $"Error al conectar con la API: {ex.Message}";
                }
            }

            return RedirectToAction("ActualizarProductos");
        }

        public async Task<ActionResult> ActualizarProducto(int Id)
        {
            Productos productos = new Productos();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"api/Productos/{Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        productos = await response.Content.ReadAsAsync<Productos>();
                    }
                    else
                    {
                        ViewBag.Mensaje = $"Error: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = $"Error al conectar con la API: {ex.Message}";
                }
            }

            return View("ActualizarProductos", productos);
        }

        public ActionResult Crear()
        {
            return View("CrearProducto");
        }

        [HttpPost]
        public async Task<ActionResult> CrearProducto(Productos Producto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(Producto);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Productos", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = "Producto creado correctamente";
                    }
                    else
                    {
                        TempData["Mensaje"] = $"Error al crear: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = $"Error al conectar con la API: {ex.Message}";
                }
            }

            return RedirectToAction("ActualizarProductos");
        }


        [HttpGet]
        public async Task<ActionResult> Eliminar(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7096/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"api/Productos/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = "Producto eliminado correctamente.";
                    }
                    else
                    {
                        TempData["Mensaje"] = $"Error al eliminar: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error al conectar con la API: " + ex.Message;
                }
            }

            return RedirectToAction("ActualizarProductos"); 
        }


    }
}