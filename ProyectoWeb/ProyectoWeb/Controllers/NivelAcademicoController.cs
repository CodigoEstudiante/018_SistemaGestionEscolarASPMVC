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
    public class NivelAcademicoController : Controller
    {
        // GET: NivelAcademico
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Listar()
        {
            List<Nivel> oListaNivel = CD_Nivel.Listar();
            return Json(new { data = oListaNivel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Nivel oNivel)
        {
            bool respuesta = true;

            try
            {
                oNivel.HoraInicio = Convert.ToDateTime(oNivel.TextoHoraInicio, new CultureInfo("es-ES"));
                oNivel.HoraFin = Convert.ToDateTime(oNivel.TextoHoraFin, new CultureInfo("es-ES"));

                if (oNivel.IdNivel == 0)
                {
                    respuesta = CD_Nivel.Registrar(oNivel);
                }
                else
                {
                    respuesta = CD_Nivel.Editar(oNivel);
                }

            }
            catch
            {

                respuesta = false;
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idnivel = 0)
        {
            bool respuesta = CD_Nivel.Eliminar(idnivel);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}