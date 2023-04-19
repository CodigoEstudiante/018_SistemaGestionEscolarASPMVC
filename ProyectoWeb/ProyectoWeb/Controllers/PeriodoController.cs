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
    public class PeriodoController : Controller
    {
        // GET: Periodo
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Listar()
        {

            List<Periodo> oListaPerido = CD_Periodo.Listar();
            return Json(new { data = oListaPerido }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Periodo oOperiodo)
        {
            bool respuesta = true;

            try
            {
                oOperiodo.FechaInicio = Convert.ToDateTime(oOperiodo.textoFechaInicio, new CultureInfo("es-ES"));
                oOperiodo.FechaFin = Convert.ToDateTime(oOperiodo.textoFechaFin, new CultureInfo("es-ES"));

                if (oOperiodo.IdPeriodo == 0)
                {
                    respuesta = CD_Periodo.Registrar(oOperiodo);
                }
                else
                {
                    respuesta = CD_Periodo.Editar(oOperiodo);
                }

            }
            catch {

                respuesta = false;
            }
            

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idperiodo = 0)
        {
            bool respuesta = CD_Periodo.Eliminar(idperiodo);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}