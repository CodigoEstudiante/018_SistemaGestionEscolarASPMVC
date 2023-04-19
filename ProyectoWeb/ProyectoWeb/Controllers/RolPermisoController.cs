using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class RolPermisoController : Controller
    {
        // GET: RolPermiso
        public ActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Obtener(int IdRol) {

            List<Permisos> oListaPermisos = CD_Permisos.Obtener(IdRol);
            return Json(oListaPermisos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(string xml) {
            bool Respuesta = false;
            Respuesta = CD_Permisos.Actualizar(xml);
            return Json(new { resultado = Respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}