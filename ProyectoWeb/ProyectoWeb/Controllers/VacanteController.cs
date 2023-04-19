using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class VacanteController : Controller
    {
        // GET: Vacante
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Listar(int idnivel = 0) {


            List<NivelDetalle> oListaNivelDetalle = CD_NivelDetalle.Listar();

            if (oListaNivelDetalle != null)
            {
                oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oNivel.IdNivel == idnivel).ToList();

            }

            return Json(oListaNivelDetalle,JsonRequestBehavior.AllowGet);
        }


        public JsonResult Guardar(string Vxml) {

            bool respuesta = CD_NivelDetalle.RegistrarVacantes(Vxml.ToString());

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

    }
}