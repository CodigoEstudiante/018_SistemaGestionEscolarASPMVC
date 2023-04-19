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
    public class CD_Horario
    {

        public static List<Horario> Listar()
        {
            List<Horario> rptListaHorario = new List<Horario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarHorario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaHorario.Add(new Horario()
                        {
                            IdHorario = Convert.ToInt32(dr["IdHorario"].ToString()),
                            oNivelDetalleCurso = new NivelDetalleCurso()
                            {
                                oCurso = new Curso()
                                {
                                    IdCurso = Convert.ToInt32(dr["IdCurso"].ToString()),
                                    Descripcion = dr["NombreCurso"].ToString()

                                },
                                oNivel = new Nivel()
                                {
                                    IdNivel = Convert.ToInt32(dr["IdNivel"].ToString())
                                },
                                oGradoSeccion = new GradoSeccion()
                                {
                                    IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString())
                                }
                            },
                            DiaSemana = dr["DiaSemana"].ToString(),
                            HoraInicio = Convert.ToDateTime( dr["HoraInicio"].ToString()),
                            HoraFin = Convert.ToDateTime( dr["HoraFin"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaHorario;

                }
                catch (Exception ex)
                {
                    rptListaHorario = null;
                    return rptListaHorario;
                }
            }
        }

        public static bool Registrar(Horario oHorario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("usp_RegistrarHorario", oConexion);
                    cmd.Parameters.AddWithValue("IdNivel", oHorario.oNivelDetalleCurso.oNivel.IdNivel);
                    cmd.Parameters.AddWithValue("IdGradoSeccion", oHorario.oNivelDetalleCurso.oGradoSeccion.IdGradoSeccion);
                    cmd.Parameters.AddWithValue("IdCurso", oHorario.oNivelDetalleCurso.oCurso.IdCurso);
                    cmd.Parameters.AddWithValue("DiaSemana", oHorario.DiaSemana);
                    cmd.Parameters.AddWithValue("HoraInicio", oHorario.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oHorario.HoraFin);
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

        public static bool Eliminar(int idHorario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarHorario", oConexion);
                    cmd.Parameters.AddWithValue("IdHorario", idHorario);
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
