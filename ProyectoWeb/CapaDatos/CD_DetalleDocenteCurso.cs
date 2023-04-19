using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_DetalleDocenteCurso
    {
        public static List<Docente> DetalleDocenteCurso()
        {
            List<Docente> oListaDocenteCurso = new List<Docente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_DetalleDocenteCurso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DOCENTES") != null)
                            {
                                oListaDocenteCurso = (from docente in doc.Element("DOCENTES").Elements("DOCENTE")
                                                      select new Docente()
                                                      {
                                                          IdDocente = int.Parse(docente.Element("IdDocente").Value),
                                                          Nombres = docente.Element("Nombres").Value,
                                                          Apellidos = docente.Element("Apellidos").Value,
                                                          oListaNivel = docente.Element("NIVELES") != null ?
                                                            (from nivel in docente.Element("NIVELES").Elements("NIVEL")
                                                             select new Nivel() {
                                                                 IdNivel = int.Parse(nivel.Element("IdNivel").Value),
                                                                 DescripcionNivel = nivel.Element("DescripcionNivel").Value,
                                                                 oListaGradoSeccion = nivel.Element("GRADOS_SECCION") != null ?
                                                                 (from gradoseccion in nivel.Element("GRADOS_SECCION").Elements("GRADO")
                                                                  select new GradoSeccion()
                                                                  {
                                                                      IdGradoSeccion = int.Parse(gradoseccion.Element("IdGradoSeccion").Value),
                                                                      DescripcionGrado = gradoseccion.Element("DescripcionGrado").Value,
                                                                      DescripcionSeccion = gradoseccion.Element("DescripcionSeccion").Value,
                                                                      oListaCurso = gradoseccion.Element("CURSOS") != null ?
                                                                      (from curso in gradoseccion.Element("CURSOS").Elements("CURSO")
                                                                       select new Curso()
                                                                       {
                                                                           IdCurso = int.Parse(curso.Element("IdCurso").Value),
                                                                           Descripcion = curso.Element("Descripcion").Value,
                                                                       }).ToList() : new List<Curso>()
                                                                  } ).ToList() : new List<GradoSeccion>()
                                                             }
                                                            ).ToList() : new List<Nivel>()
                                                      }


                                    ).ToList();
                            }
                            else
                            {
                                oListaDocenteCurso = new List<Docente>();
                            }
                        }

                        dr.Close();

                    }

                    return oListaDocenteCurso;
                }
                catch (Exception ex)
                {
                    oListaDocenteCurso = new List<Docente>();
                    return oListaDocenteCurso;
                }
            }
        }


        public static bool Registrar(DocenteCurso oDocenteCurso, string Descripcion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarCurricula", oConexion);
                    cmd.Parameters.AddWithValue("IdNivel", oDocenteCurso.oNivelDetalleCurso.oNivel.IdNivel);
                    cmd.Parameters.AddWithValue("IdGradoSeccion", oDocenteCurso.oNivelDetalleCurso.oGradoSeccion.IdGradoSeccion);
                    cmd.Parameters.AddWithValue("IdCurso", oDocenteCurso.oNivelDetalleCurso.oCurso.IdCurso);
                    cmd.Parameters.AddWithValue("IdDocente", oDocenteCurso.oDocente.IdDocente);
                    cmd.Parameters.AddWithValue("Descripcion", Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
