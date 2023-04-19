using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Crear()
        {
            //ViewBag.Message = "Crear Rol";
            return View();
        }

        public JsonResult Listar() {

            List<Rol> oListaRol = CD_Rol.Listar();
            return Json(new { data = oListaRol }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Obtener(int idrol = 0)
        {
            Rol oRol = CD_Rol.Listar().Where(x => x.IdRol == idrol).FirstOrDefault();

            return Json(oRol, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Rol oRol)
        {
            bool respuesta = false;

            if (oRol.IdRol == 0) {
                respuesta = CD_Rol.Registrar(oRol);
            }
            else {
                respuesta = CD_Rol.Editar(oRol);
            }
            

            return Json(new {resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idrol = 0)
        {
            bool respuesta = CD_Rol.Eliminar(idrol);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}