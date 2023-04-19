using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class GradoSeccionController : Controller
    {
        // GET: GradoSeccion
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Listar()
        {
            List<GradoSeccion> oListaGradoSeccion = CD_GradoSeccion.Listar();
            return Json(new { data = oListaGradoSeccion }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarGradosxNivel(int idnivel = 0)
        {

            List<NivelDetalle> oListaNivelDetalle = CD_NivelDetalle.Listar();

            if (oListaNivelDetalle != null)
            {
                oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oNivel.IdNivel == idnivel).ToList();
            }

            return Json( oListaNivelDetalle , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(GradoSeccion oGradoSeccion)
        {
            bool respuesta = true;

            try
            {
                if (oGradoSeccion.IdGradoSeccion == 0)
                {
                    respuesta = CD_GradoSeccion.Registrar(oGradoSeccion);
                }
                else
                {
                    respuesta = CD_GradoSeccion.Editar(oGradoSeccion);
                }

            }
            catch
            {

                respuesta = false;
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idgradoseccion = 0)
        {
            bool respuesta = CD_GradoSeccion.Eliminar(idgradoseccion);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}