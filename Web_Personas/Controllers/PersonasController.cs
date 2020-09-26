using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


//importacion
using Web_Personas.Models;
using Newtonsoft.Json;

namespace Web_Personas.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            var wc = new System.Net.WebClient();
            var url = "http://localhost:61785/api/Persona";
            //invoca al web service de tipo rest
            var res = wc.DownloadString(url);
            //lo manda y lo recibimos y para eso instalamos Newtonsoft.Json
            //en json 
            //deserializar el json y convierte en array de productos
            Personas[] data = Newtonsoft.Json.JsonConvert.DeserializeObject<Personas[]>(res);
            
            return View(data);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            var wc = new System.Net.WebClient();
            //le pasamos el id de la persona
            var url = "http://localhost:61785/api/Persona/"+id.ToString();
            //invoca al web service de tipo rest
            var res = wc.DownloadString(url);
            //lo manda y lo recibimos y para eso instalamos Newtonsoft.Json
            //en json 
            //deserializar el json y convierte en array de productos
            Personas data = Newtonsoft.Json.JsonConvert.DeserializeObject<Personas>(res);
            return View(data);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personas data)
        {
            //recibe En el Modalo Personas data
            try
            {
                var wc = new System.Net.WebClient();
                var url = "http://localhost:61785/api/Persona";
                //serializar en formato JSON los datos del producto
                var json = JsonConvert.SerializeObject(data);
                //configuramos el web client para enviar el json
                wc.Headers.Add("Content-Type", "application/json");
                //enviamos el JSON al web service
                wc.UploadString(url, json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            //antes de invocar traer el dato de la persona
            var wc = new System.Net.WebClient();
            var url = "http://localhost:61785/api/Persona/"+id.ToString();
            //invoca al web service de tipo rest
            var res = wc.DownloadString(url);
            //lo manda y lo recibimos y para eso instalamos Newtonsoft.Json
            //en json 
            //deserializar el json y convierte en objeto de productos
            Personas data = Newtonsoft.Json.JsonConvert.DeserializeObject<Personas>(res);
            //se obtine y se envia a la vista
            return View(data);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Personas data)
        {
            try
            {
                var wc = new System.Net.WebClient();
                //agregamos el id de la persona que se va a editar
                var url = "http://localhost:61785/api/Persona/"+id.ToString();
                //serializar en formato JSON los datos del producto
                var json = JsonConvert.SerializeObject(data);
                //configuramos el web client para enviar el json
                wc.Headers.Add("Content-Type", "application/json");
                //enviamos el JSON al web service como PUT para editarlo
                wc.UploadString(url,"PUT", json);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Regresa la vista
        public ActionResult Delete(int id)
        {
            //antes de invocar traer el dato de la persona a eliminar
            var wc = new System.Net.WebClient();
            var url = "http://localhost:61785/api/Persona/" + id.ToString();
            //invoca al web service de tipo rest
            var res = wc.DownloadString(url);
            //lo manda y lo recibimos y para eso instalamos Newtonsoft.Json
            //en json 
            //deserializar el json y convierte en objeto de productos
            Personas data = Newtonsoft.Json.JsonConvert.DeserializeObject<Personas>(res);
            //se obtine y se envia a la vista
            return View(data);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var wc = new System.Net.WebClient();
                //agregamos el id del usuario a
                var url = "http://localhost:61785/api/Persona/" + id.ToString();
                wc.UploadString(url, "DELETE", "");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
