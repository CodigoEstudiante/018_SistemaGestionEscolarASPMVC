using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Matricula
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerCantidadVacantes(int idnivel, int idgradoseccion) {

            List<NivelDetalle> oListaNivelDetalle = CD_NivelDetalle.Listar();
            string cantidad ="";
            cantidad = oListaNivelDetalle.FirstOrDefault(x => x.oNivel.IdNivel == idnivel && x.oGradoSeccion.IdGradoSeccion == idgradoseccion).VacantesDisponibles.ToString();

            return Json(cantidad, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Registrar(string requestXML) {
            int Respuesta = CD_Matricula.Registrar(requestXML);

            return Json(new { resultado = Respuesta }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult ConsultaReporte(string codigomatricula,string situacionmatricula, string codigoalumno, string nombres, string apellidos, string documentoidentidad, string periodo, string nivelacademico, string gradoseccion)
        {

            DataTable dt = new DataTable();
            
            dt = CD_Matricula.Reporte(
                codigomatricula,
                situacionmatricula,
                codigoalumno,
                documentoidentidad,
                nombres,
                apellidos,
                periodo,
                nivelacademico,
                gradoseccion
                );


            return Json(new { data = DataTableToJSONWithJavaScriptSerializer(dt) }, JsonRequestBehavior.AllowGet);

        }

        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }


    }
}