using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Asignar()
        {
            return View();
        }

        public ActionResult Crear() {

            return View();
        }


        public JsonResult CursosxNivelGrado(int idnivel = 0, int idgradoseccion = 0)
        {
            List<Curso> oLista = new List<Curso>();

            List<Curso> oListaCursosAsignados = new List<Curso>();

            List<Curso> oListaCurso = CD_Curso.Listar();
            List<NivelDetalleCurso> oListaNivelDetalleCurso = CD_NivelDetalleCurso.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if (oListaNivelDetalleCurso != null)
            {
                oListaNivelDetalleCurso = oListaNivelDetalleCurso.Where(x =>
                x.oNivel.IdNivel == idnivel &&
                x.oGradoSeccion.IdGradoSeccion == idgradoseccion).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if (oListaCurso != null && oListaNivelDetalleCurso != null)
            {
                oListaCursosAsignados = (from a in oListaCurso
                                         join b in oListaNivelDetalleCurso on a.IdCurso equals b.oCurso.IdCurso
                                         select a).ToList();

                foreach (Curso a in oListaCurso)
                {
                    bool encontrado = false;
                    foreach (Curso b in oListaCursosAsignados)
                    {
                        if (a.IdCurso == b.IdCurso)
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    a.Asignado = encontrado;
                    oLista.Add(a);
                }
            }

            return Json(oLista, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarAsignacion(string Vxml)
        {
            bool respuesta = CD_NivelDetalleCurso.Asignar(Vxml);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Listar()
        {
            List<Curso> oListaCurso = CD_Curso.Listar();
            return Json(new {data = oListaCurso }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Curso oCurso)
        {
            bool respuesta = false;

            if (oCurso.IdCurso == 0) {
                respuesta = CD_Curso.Registrar(oCurso);
            }

            
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idcurso = 0)
        {
            bool respuesta = CD_Curso.Eliminar(idcurso);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }




    }
}