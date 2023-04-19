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
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Asignar() {
            return View();
        }

        public ActionResult Curricula() {
            return View();
        }


        public ActionResult Calificacion() {

            return View();
        }

        public JsonResult Listar()
        {
            List<Docente> oListaDocente = CD_Docente.Listar();
            return Json(new { data = oListaDocente }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarAsignados(int idnivel = 0, int idgradoseccion = 0)
        {

            //MOSTRAMOS TODOS LOS HORARIOS POR NIVEL Y GRADOSECCION
            List<DocenteCurso> oListaDocenteCurso = CD_DocenteCurso.Listar();
            oListaDocenteCurso = oListaDocenteCurso.Where(x => x.oNivelDetalleCurso.oNivel.IdNivel == idnivel && x.oNivelDetalleCurso.oGradoSeccion.IdGradoSeccion == idgradoseccion).ToList();

            return Json(new { data = oListaDocenteCurso }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarAsignacion(DocenteCurso oDocenteCurso)
        {
            bool respuesta = CD_DocenteCurso.Registrar(oDocenteCurso);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Docente oDocente)
        {
            bool respuesta = true;

            try
            {
                oDocente.FechaNacimiento = Convert.ToDateTime(oDocente.TextoFechaNacimiento, new CultureInfo("es-ES"));

                if (oDocente.IdDocente == 0)
                {
                    respuesta = CD_Docente.Registrar(oDocente);
                }
                else
                {
                    respuesta = CD_Docente.Editar(oDocente);
                }

            }
            catch
            {

                respuesta = false;
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int iddocente = 0)
        {
            bool respuesta = CD_Docente.Eliminar(iddocente);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult NivelAcademicoxDocente(int iddocente = 0)
        {
            List<Docente> oListaDocenteCurso = new List<Docente>();
            List<Docente> oListaDocenteCursoTemp = new List<Docente>();
            List<Nivel> oListaNivel = new List<Nivel>();


            oListaDocenteCurso = CD_DetalleDocenteCurso.DetalleDocenteCurso();
            oListaDocenteCursoTemp = oListaDocenteCurso.Where(x => x.IdDocente == iddocente).ToList();
            oListaNivel = (from lista in oListaDocenteCursoTemp from temp in lista.oListaNivel select temp).ToList();


            return Json(oListaNivel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GradoSeccionxDocente(int idnivel = 0, int iddocente = 0) {

            List<Docente> oListaDocenteCurso = new List<Docente>();
            List<Docente> oListaDocenteCursoTemp = new List<Docente>();
            List<Nivel> oListaNivel = new List<Nivel>();


            oListaDocenteCurso = CD_DetalleDocenteCurso.DetalleDocenteCurso();
            oListaDocenteCursoTemp = oListaDocenteCurso.Where(x => x.IdDocente == iddocente).ToList();
            oListaNivel = (from lista in oListaDocenteCursoTemp from temp in lista.oListaNivel select temp).ToList();

            List<GradoSeccion> oListaGradoSeccion = new List<GradoSeccion>();

            oListaGradoSeccion = (from lista in oListaNivel
                                  where lista.IdNivel == idnivel
                                  from temp in lista.oListaGradoSeccion
                                  select temp).ToList();

            return Json(oListaGradoSeccion, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult CursosxDocente(int idgradoseccion = 0, int idnivel = 0, int iddocente = 0) {


            List<Docente> oListaDocenteCurso = new List<Docente>();
            List<Docente> oListaDocenteCursoTemp = new List<Docente>();
            List<Nivel> oListaNivel = new List<Nivel>();
            List<Curso> oListaCurso = new List<Curso>();

            oListaDocenteCurso = CD_DetalleDocenteCurso.DetalleDocenteCurso();
            oListaDocenteCursoTemp = oListaDocenteCurso.Where(x => x.IdDocente == iddocente).ToList();
            oListaNivel = (from lista in oListaDocenteCursoTemp from temp in lista.oListaNivel select temp).ToList();

            List<GradoSeccion> oListaGradoSeccion = new List<GradoSeccion>();

            oListaGradoSeccion = (from lista in oListaNivel
                                  where lista.IdNivel == idnivel
                                  from temp in lista.oListaGradoSeccion
                                  select temp).ToList();

            oListaCurso = (from lista in oListaGradoSeccion
                           where lista.IdGradoSeccion == idgradoseccion
                           from temp in lista.oListaCurso
                           select temp).ToList();

            return Json(oListaCurso, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgregarCurricula(DocenteCurso oDocenteCurso, string conceptoCurricula) {

            bool respuesta = CD_DetalleDocenteCurso.Registrar(oDocenteCurso, conceptoCurricula);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult EliminarCurricula(int IdCurricula = 0)
        {

            bool Respuesta = CD_Currricula.Eliminar(IdCurricula);
            return Json(new { resultado = Respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarCurricula(int idgradoseccion = 0, int idnivel = 0, int iddocente = 0,int idcurso = 0) {

            List<Curricula> oListaCurricula = CD_Currricula.Listar(idnivel, idgradoseccion, idcurso, iddocente);
            return Json(new { data = oListaCurricula }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerNotas(int idnivel, int idgradoseccion, int idcurso, int iddocente, int idalumno) {

            //LISTAMOS CURRICULA
            List<Curricula> oListaCurricula = CD_Currricula.Listar(idnivel, idgradoseccion, idcurso, iddocente);
            List<Calificacion> oListaCalificacion = CD_Calificacion.Listar(idnivel, idgradoseccion, idcurso, idalumno);

            List<Calificacion> oListaCalificacionTemp = new List<Calificacion>();


            foreach (Curricula cu in oListaCurricula)
            {
                bool encontrado = false;
                foreach (Calificacion ca in oListaCalificacion)
                {
                    if (cu.IdCurricula == ca.oCurricula.IdCurricula)
                    {
                        encontrado = true;
                        oListaCalificacionTemp.Add(new Calificacion()
                        {
                            oCurricula = new Curricula()
                            {
                                IdCurricula = ca.oCurricula.IdCurricula,
                                Descripcion = ca.oCurricula.Descripcion,
                            },
                            Nota = ca.Nota
                        });
                        break;
                    }
                }
                if (!encontrado)
                {
                    oListaCalificacionTemp.Add(new Calificacion()
                    {
                        oCurricula = new Curricula()
                        {
                            IdCurricula = cu.IdCurricula,
                            Descripcion = cu.Descripcion,
                        },
                        Nota = 0
                    });
                }

            }

            return Json(oListaCalificacionTemp, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarNotas(string requestXML) {

            bool Respuesta = CD_Calificacion.Registrar(requestXML);
            return Json(new { resultado = Respuesta }, JsonRequestBehavior.AllowGet);
        }

     
        [HttpGet]
        public JsonResult ObtenerAlumnosAsignados(int idgradoseccion = 0, int idnivel = 0) {

            List<Matricula> oListaMatricula = CD_Matricula.Listar();

            oListaMatricula = oListaMatricula.Where(x => x.oNivelDetalle.oNivel.IdNivel == idnivel && x.oNivelDetalle.oGradoSeccion.IdGradoSeccion == idgradoseccion).ToList();
            return Json(oListaMatricula, JsonRequestBehavior.AllowGet);
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