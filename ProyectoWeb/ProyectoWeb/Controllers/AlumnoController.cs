using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }

        public JsonResult Listar()
        {

            List<Alumno> oListaAlumno = CD_Alumno.Listar();
            return Json(new { data = oListaAlumno }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Alumno oAlumno)
        {
            bool respuesta = true;

            try
            {
                oAlumno.FechaNacimiento = Convert.ToDateTime(oAlumno.TextoFechaNacimiento, new CultureInfo("es-ES"));

                if (oAlumno.IdAlumno == 0)
                {
                    respuesta = CD_Alumno.Registrar(oAlumno);
                }
                else
                {
                    respuesta = CD_Alumno.Editar(oAlumno);
                }

            }
            catch
            {

                respuesta = false;
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idalumno = 0)
        {
            bool respuesta = CD_Alumno.Eliminar(idalumno);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult ConsultaReporte(string nombres, string apellidos, string codigo, string documentoidentidad)
        {

            DataTable dt = new DataTable();

            dt = CD_Alumno.Reporte(nombres, apellidos, codigo, documentoidentidad);

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