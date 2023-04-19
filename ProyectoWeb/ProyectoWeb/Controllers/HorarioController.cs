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
    public class HorarioController : Controller
    {
        // GET: Horario
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Listar(int idnivel = 0, int idgradoseccion = 0) {

            //MOSTRAMOS TODOS LOS HORARIOS POR NIVEL Y GRADOSECCION
            List<Horario> oListaHorario = CD_Horario.Listar();
            oListaHorario = oListaHorario.Where(x => x.oNivelDetalleCurso.oNivel.IdNivel == idnivel && x.oNivelDetalleCurso.oGradoSeccion.IdGradoSeccion == idgradoseccion).ToList();

            return Json( new { data = oListaHorario } , JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Asignar(Horario oHorario) {
            
            oHorario.HoraInicio = Convert.ToDateTime(oHorario.TextoHoraInicio, new CultureInfo("es-ES"));
            oHorario.HoraFin = Convert.ToDateTime(oHorario.TextoHoraFin, new CultureInfo("es-ES"));

            bool respuesta = CD_Horario.Registrar(oHorario);


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Eliminar(int idhorario = 0) {
            bool respuesta = CD_Horario.Eliminar(idhorario);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }
        

    }
}