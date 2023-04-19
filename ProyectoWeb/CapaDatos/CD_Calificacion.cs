using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Calificacion
    {
        public static List<Calificacion> Listar(int IdNivel, int IdGradoSeccion, int IdCurso, int IdAlumno)
        {

            List<Calificacion> rptListaCalificacion = new List<Calificacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
        
                SqlCommand cmd = new SqlCommand("usp_ObtenerClalificacion", oConexion);
                cmd.Parameters.AddWithValue("IdNivel", IdNivel);
                cmd.Parameters.AddWithValue("IdGradoSeccion", IdGradoSeccion);
                cmd.Parameters.AddWithValue("IdCurso", IdCurso);
                cmd.Parameters.AddWithValue("IdAlumno", IdAlumno);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCalificacion.Add(new Calificacion()
                        {   Nota = float.Parse(dr["Nota"].ToString()),
                            oCurricula = new Curricula()
                            {
                                IdCurricula = Convert.ToInt32(dr["IdCurricula"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                oDocenteCurso = new DocenteCurso()
                                {
                                    oNivelDetalleCurso = new NivelDetalleCurso()
                                    {
                                        oCurso = new Curso() { IdCurso = Convert.ToInt32(dr["IdCurso"].ToString()) },
                                        oGradoSeccion = new GradoSeccion() { IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()) },
                                        oNivel = new Nivel() { IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()) }
                                    }
                                }
                            },
                            oAlumno = new Alumno() { IdAlumno = Convert.ToInt32(dr["IdAlumno"].ToString()) },
                            
                        });
                    }
                    dr.Close();

                    return rptListaCalificacion;

                }
                catch (Exception ex)
                {
                    rptListaCalificacion = new List<Calificacion>();
                    return rptListaCalificacion;
                }
            }
        }

        public static bool Registrar(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarCalificacion", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
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
