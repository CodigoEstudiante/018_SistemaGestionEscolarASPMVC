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
    public class CD_NivelDetalleCurso
    {

        public static List<NivelDetalleCurso> Listar()
        {
            List<NivelDetalleCurso> rptListaNivelDetalleCurso = new List<NivelDetalleCurso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarCursosAsignados", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaNivelDetalleCurso.Add(new NivelDetalleCurso()
                        {
                            IdNivelDetalleCurso = Convert.ToInt32(dr["IdNivelDetalleCurso"].ToString()),
                            oNivelDetalle = new NivelDetalle() { IdNivelDetalle = Convert.ToInt32(dr["IdNivelDetalle"].ToString()) },
                            oNivel = new Nivel()
                            {
                                IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()),
                                DescripcionNivel = dr["DescripcionNivel"].ToString(),
                                DescripcionTurno = dr["DescripcionTurno"].ToString(),
                                HoraInicio = Convert.ToDateTime(dr["HoraInicio"].ToString()),
                                HoraFin = Convert.ToDateTime(dr["HoraFin"].ToString())
                            },
                            oGradoSeccion = new GradoSeccion()
                            {
                                IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()),
                                DescripcionGrado = dr["DescripcionGrado"].ToString(),
                                DescripcionSeccion = dr["DescripcionSeccion"].ToString()
                            },
                            oCurso = new Curso()
                            {
                                IdCurso = Convert.ToInt32(dr["IdCurso"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                Activo = Convert.ToBoolean(dr["CursoActivo"]), 
                            }

                        });
                    }
                    dr.Close();

                    return rptListaNivelDetalleCurso;

                }
                catch (Exception ex)
                {
                    rptListaNivelDetalleCurso = null;
                    return rptListaNivelDetalleCurso;
                }
            }
        }

        public static bool Asignar(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_AsginarCursos", oConexion);
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
