using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoWeb.Controllers
{
    public class GradoporNivelController : Controller
    {
        // GET: GradoporNivel
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Listar(int idnivel = 0) {

            List<GradoSeccion> oLista = new List<GradoSeccion>();

            List<GradoSeccion> oListaGradoSeccionAsignados = new List<GradoSeccion>();

            List<GradoSeccion> oListaGradoSeccion = CD_GradoSeccion.Listar();
            List<NivelDetalle> oListaNivelDetalle = CD_NivelDetalle.Listar();

            //FILTRAMOS SEGUN NUESTRO PARAMETROS DE FILTRO
            if (oListaNivelDetalle != null)
            {
                oListaNivelDetalle = oListaNivelDetalle.Where(x => x.oNivel.IdNivel == idnivel).ToList();

            }

            //OBTENEMOS LOS POR ASIGNAR Y LOS ASIGNADOS
            if (oListaGradoSeccion != null && oListaNivelDetalle != null)
            {
                oListaGradoSeccionAsignados = (from a in oListaNivelDetalle
                                               join b in oListaGradoSeccion on a.oGradoSeccion.IdGradoSeccion equals b.IdGradoSeccion
                                               select b).ToList();

                foreach (GradoSeccion a in oListaGradoSeccion)
                {
                    bool encontrado = false;
                    foreach (GradoSeccion b in oListaGradoSeccionAsignados)
                    {
                        if (a.IdGradoSeccion == b.IdGradoSeccion)
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
        public JsonResult Guardar(string Vxml)
        {
            bool respuesta = CD_NivelDetalle.Registrar(Vxml);


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}